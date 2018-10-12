using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Xml.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordReporter
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        PackedTemplate template = new PackedTemplate();

        private void OpenInWordBtn_Click(object sender, EventArgs e)
        {
            Process.Start(template.OpenDocx());
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            /*if (template.Guid != String.Empty)
            {
                DialogResult result = MessageBox.Show(
                    "Текущий документ не сохранен. Сохранить его перед открытием нового?", 
                    "Внимание!", 
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Asterisk,
                    MessageBoxDefaultButton.Button1);
            }*/
            Stream zipStream = null;
            OpenFileDialog fileOpen = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Filter = "Архив (*.zip)|*.zip|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };
            if (fileOpen.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((zipStream = fileOpen.OpenFile()) != null)
                    {
                        template.InitializeTemplate(zipStream);
                        if ((template.Guid != null) && (template.Name != null))
                        {
                            template.Path = fileOpen.FileName;
                            name.Text = template.Name;
                            name.Enabled = true;
                            guid.Text = template.Guid;
                            guid.Enabled = true;
                            guidGenBtn.Enabled = true;
                            openInWordBtn.Enabled = true;
                            saveAsFile.Enabled = true;
                            saveFile.Enabled = true;
                            saveBtn.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Фаил не является архивом шаблона");
                            if (Directory.Exists(template.TempFolder)) Directory.Delete(template.TempFolder, true);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void GuidGenBtn_Click(object sender, EventArgs e)
        {
            if (template.DefGuid != string.Empty)
            {
                defGuidBtn.Enabled = true;
            }
            guid.Text = Guid.NewGuid().ToString();
        }

        private void DefGuidBtn_Click(object sender, EventArgs e)
        {
            guid.Text = template.DefGuid;
        }

        private void CreateFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileOpen = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Filter = "Word документ (*.docx)|*.docx|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };
            if (fileOpen.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((fileOpen.OpenFile()) != null)
                    {
                        template.InitializeTemplate(fileOpen.FileName);
                        name.Text = template.Name;
                        name.Enabled = true;
                        guid.Text = template.Guid;
                        guid.Enabled = true;
                        guidGenBtn.Enabled = true;
                        openInWordBtn.Enabled = true;
                        saveAsFile.Enabled = true;
                        if (saveBtn.AccessibleName == "save") //если еще не загружался документ установить обработчик 
                        {
                            saveBtn.Click += new EventHandler(SaveAsFile_Click);
                            saveBtn.Enabled = true;
                            saveBtn.AccessibleName = "saveAs";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void SaveFile_Click(object sender, EventArgs e)
        {
            if(File.Exists(template.Path))
            {
                template.Guid = guid.Text;
                template.Name = name.Text;
                template.BuildTemplate();
                FileStream zip = new FileStream(template.Path, FileMode.Open);
                Document.CreateTemplate(zip, template.TempFolder);
                MessageBox.Show("Файл успешно сохранен");
            }
        }

        private void SaveAsFile_Click(object sender, EventArgs e)
        {
            Stream saveTemplate = null;
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Архив (*.zip)|*.zip|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true,
                OverwritePrompt = true,
                AddExtension = true,
                DefaultExt = "zip"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                try
                {
                    if ((saveTemplate = saveFileDialog.OpenFile()) != null)
                    {
                        template.Guid = guid.Text;
                        template.Name = name.Text;
                        template.BuildTemplate();
                        Document.CreateTemplate(saveTemplate, template.TempFolder);
                        template.Path = saveFileDialog.FileName;
                        MessageBox.Show("Файл успешно сохранен");
                        if (saveBtn.AccessibleName == "saveAs") // если было сохранить как, то поменять
                        {
                            saveBtn.Click -= new EventHandler(SaveAsFile_Click);
                            saveBtn.Click += new EventHandler(SaveFile_Click);
                            saveBtn.AccessibleName = "save";
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (File.Exists(template.TempFolder + @"\" + Document.DEF_DOCX_ZIP))
                    { File.Delete(template.TempFolder + @"\" + Document.DEF_DOCX_ZIP); }
                    MessageBox.Show(ex.Message);
                }

        }

        private void about_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Версия программы 0.8 beta",
                "О программе"
                );
        }
    }



    class PackedTemplate
    {
        private string path = string.Empty;
        private string name = string.Empty;
        private string guid = string.Empty;
        private string defGuid = string.Empty;
        private string docxPath = string.Empty;
        private string tempFolder = string.Empty;

        public string Name { get => name; set => name = value; }
        public string Guid { get => guid; set => guid = value; }
        public string TempFolder { get => tempFolder; } 
        public string DefGuid { get => defGuid; }
        public string Path { get => path; set => path = value; }

        public string OpenDocx() => docxPath;

        public void InitializeTemplate(Stream file)
        {
            tempFolder = Document.Unzip(file);
            docxPath = Document.GetDocx(tempFolder);
            name = Document.GetName(tempFolder);
            guid = Document.GetGuid(tempFolder);
            defGuid = guid;

        }
        public void InitializeTemplate(string docx)
        {
            tempFolder = System.IO.Path.GetTempPath() + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            docxPath = Document.GetDocx(docx, tempFolder);
            name = "Договор";
            guid = "00000000-0000-0000-0000-000000000000";
        }   
        
        ~PackedTemplate()
        {
            if(Directory.Exists(tempFolder)) Directory.Delete(tempFolder, true);
        }
        public void BuildTemplate()
        {
            string docxZipName = Document.ZipDocx(tempFolder);
            File.WriteAllText(tempFolder + @"\repTempl_Data0.xml", docxZipName);
            File.WriteAllText(tempFolder + @"\repTempl_defData0.xml", docxZipName);
            BuildPropXml();
            BuildDescription();
        }
        private void BuildPropXml()
        {
            XDocument prop = new XDocument(
                new XElement("templateFiles",
                    new XElement("Items",
                        new XElement("Item",
                        new XAttribute("name", Document.DEF_DOCX_NAME))),
                    new XElement("WEB_Ready"))
            );
            prop.Save(tempFolder + @"\repTempl_defProp0.xml");
            File.Copy(tempFolder + @"\repTempl_defProp0.xml", tempFolder + @"\repTempl_Prop0.xml", true);
        }
        private void BuildDescription()
        {
            XDocument description = new XDocument(
                new XElement("reportStruct",
                    new XAttribute(XNamespace.Xmlns + "xsi", "http://www.w3.org/2001/XMLSchema-instance"),
                    new XAttribute(XNamespace.Xmlns + "xsd", "http://www.w3.org/2001/XMLSchema"),
                    new XAttribute("guid", guid),
                    new XAttribute("name", name),
                    new XAttribute("useGen", "false"),
                    new XAttribute("needSel", "1"),
                    new XAttribute("dllName", ""),
                    new XAttribute("objName", "Contract"),
                    new XAttribute("formsList", "1,3"),
                    new XElement("templates",
                        new XElement("template",
                        new XAttribute("name", name),
                        new XAttribute("guid", guid),
                        new XAttribute("default_filename", "repTempl_defData0.xml"),
                        new XAttribute("filename", "repTempl_Data0.xml"),
                        new XAttribute("default_propfilename", "repTempl_defProp0.xml"),
                        new XAttribute("propfilename", "repTempl_Prop0.xml"),
                        new XAttribute("useInWEB", "true"))))
                );
            description.Save(tempFolder + @"\description.xml");
            /*
            XDocument description = XDocument.Load(tempFolder + @"\description.xml");
            XElement report = description.Element("reportStruct");
            if (report.Attribute("guid").Value != guid) report.Attribute("guid").Value = guid;
            if (report.Attribute("name").Value != name) report.Attribute("name").Value = name;
            XElement templ = description.Element("reportStruct").Element("templates").Element("template");
            if (templ.Attribute("guid").Value != guid) templ.Attribute("guid").Value = guid;
            if (templ.Attribute("name").Value != name) templ.Attribute("name").Value = name;
            description.Save(tempFolder + @"\description.xml");
            */
        }

    }

    class Document
    {
        public const string DEF_DOCX_NAME = "template.docx";
        public const string DEF_DOCX_ZIP = "template.zip";
        public const string DEF_DOCX_DIR = @"\template";
        public const string DEF_TEMPLATE = "resource.pack";

        public static string Unzip(Stream zip)
        {
            string unzipPath = Path.GetTempPath() + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            Directory.CreateDirectory(unzipPath);
            using (ZipArchive archive = new ZipArchive(zip, ZipArchiveMode.Read))
            {
                foreach (ZipArchiveEntry file in archive.Entries)
                {
                    if (file.Name == "description.xml") file.ExtractToFile(unzipPath + @"\description.xml");

                    if (file.Name.EndsWith(".zip", StringComparison.OrdinalIgnoreCase))
                    {
                        file.ExtractToFile(unzipPath + @"\" + file.Name);
                    }
                }
            }
            return unzipPath;
        }
        /*
        public static string Unzip(string zip)
        {
            string unzipPath = Path.GetTempPath() + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            Directory.CreateDirectory(unzipPath);
            using (ZipArchive archive = ZipFile.Open(zip, ZipArchiveMode.Read))
            {
                foreach (ZipArchiveEntry file in archive.Entries)
                {
                    if (file.Name == "description.xml") file.ExtractToFile(unzipPath + @"\description.xml");

                    if (file.Name.EndsWith(".zip", StringComparison.OrdinalIgnoreCase))
                    {
                        file.ExtractToFile(unzipPath + @"\" + file.Name);
                    }
                }
            }
            return unzipPath;
        }
        */
        public static string GetName(string folder)
        {
            if (File.Exists(folder + @"\description.xml"))
            {
                XDocument description = XDocument.Load(folder + @"\description.xml");
                XElement templ = description.Element("reportStruct").Element("templates").Element("template");
                return templ.Attribute("name").Value;
            }
            else return null;
        }
        public static string GetGuid(string folder)
        {
            if (File.Exists(folder + @"\description.xml"))
            {
                XDocument description = XDocument.Load(folder + @"\description.xml");
                XElement templ = description.Element("reportStruct").Element("templates").Element("template");
                return templ.Attribute("guid").Value;
            }
            else return null;
        }
        public static string GetDocx(string folder)
        {
            Directory.CreateDirectory(folder + DEF_DOCX_DIR);
            string[] docZip = Directory.GetFiles(folder, "*.zip");
            ZipFile.ExtractToDirectory(docZip[0], folder + DEF_DOCX_DIR);
            string[] docx = Directory.GetFiles(folder + DEF_DOCX_DIR, "*.docx");
            if (docx[0] != (folder + DEF_DOCX_DIR + @"\" + DEF_DOCX_NAME))
            {
                File.Move(docx[0], (folder + DEF_DOCX_DIR + @"\" + DEF_DOCX_NAME));
            }
            File.Delete(docZip[0]);
            return folder + DEF_DOCX_DIR + @"\" + DEF_DOCX_NAME;
        }
        public static string GetDocx(string docx, string folder)
        {
            Directory.CreateDirectory(folder + DEF_DOCX_DIR);
            File.Copy(docx, (folder + DEF_DOCX_DIR + @"\" + DEF_DOCX_NAME), true);
            return folder + DEF_DOCX_DIR + @"\" + DEF_DOCX_NAME;
        }
        public static string ZipDocx(string folder)
        {
            if (!File.Exists(folder + @"\" + DEF_DOCX_ZIP))
            {
                ZipFile.CreateFromDirectory(folder + DEF_DOCX_DIR, folder + @"\" + DEF_DOCX_ZIP);
            }
            return DEF_DOCX_ZIP;
        }
        public static void CreateTemplate(Stream saveArchive, string folder)
        {
           
            using (ZipArchive archive = new ZipArchive(saveArchive, ZipArchiveMode.Update))
            {
                if(archive.Entries != null)
                {
                    for (int i = (archive.Entries.Count -1); i >= 0; i--)
                    {
                        archive.Entries[i].Delete();
                    }
                }
                archive.CreateEntryFromFile(folder + @"\" + DEF_DOCX_ZIP, DEF_DOCX_ZIP);
                archive.CreateEntryFromFile(folder + @"\description.xml", "description.xml");
                archive.CreateEntryFromFile(folder + @"\repTempl_Data0.xml", "repTempl_Data0.xml");
                archive.CreateEntryFromFile(folder + @"\repTempl_Prop0.xml", "repTempl_Prop0.xml");
                archive.CreateEntryFromFile(folder + @"\repTempl_defData0.xml", "repTempl_defData0.xml");
                archive.CreateEntryFromFile(folder + @"\repTempl_defProp0.xml", "repTempl_defProp0.xml");
            }
        }
    }
}
