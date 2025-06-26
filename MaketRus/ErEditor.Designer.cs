namespace ErEditorProject
{
    partial class ErEditor
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErEditor));
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            newErSchemaItem = new ToolStripMenuItem();
            eRдиаграммаToolStripMenuItem1 = new ToolStripMenuItem();
            элементToolStripMenuItem = new ToolStripMenuItem();
            множествоСущностейToolStripMenuItem = new ToolStripMenuItem();
            множествоСвязейToolStripMenuItem = new ToolStripMenuItem();
            множествоЗначенийToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            openErSchemaItem = new ToolStripMenuItem();
            сохранитьToolStripMenuItem = new ToolStripSeparator();
            saveToolStripMenuItem = new ToolStripMenuItem();
            сохранитьКакToolStripMenuItem1 = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            экспортироватьToolStripMenuItem = new ToolStripMenuItem();
            eRсхемуToolStripMenuItem1 = new ToolStripMenuItem();
            eRдиаграммуToolStripMenuItem = new ToolStripMenuItem();
            редактироватьToolStripMenuItem = new ToolStripMenuItem();
            копироватьToolStripMenuItem = new ToolStripMenuItem();
            вставитьToolStripMenuItem = new ToolStripMenuItem();
            дубликатToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            удалитьToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripSplitButton();
            eRДиаграммаToolStripMenuItem3 = new ToolStripMenuItem();
            eRToolStripMenuItem = new ToolStripMenuItem();
            элементToolStripMenuItem1 = new ToolStripMenuItem();
            множествоСущностейToolStripMenuItem1 = new ToolStripMenuItem();
            множествоСвязейToolStripMenuItem1 = new ToolStripMenuItem();
            множествоЗначенийToolStripMenuItem1 = new ToolStripMenuItem();
            toolStripSplitButton1 = new ToolStripSplitButton();
            eRсхемаToolStripMenuItem = new ToolStripMenuItem();
            toolStripButton2 = new ToolStripButton();
            splitContainer1 = new SplitContainer();
            groupBox1 = new GroupBox();
            navigatorPanel1 = new NavigatorTree();
            toolStrip2 = new ToolStrip();
            toolStripButton10 = new ToolStripButton();
            toolStripButton3 = new ToolStripButton();
            toolStripButton4 = new ToolStripButton();
            toolStripButton5 = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripButton6 = new ToolStripButton();
            toolStripButton7 = new ToolStripButton();
            toolStripSeparator3 = new ToolStripButton();
            toolStripButton8 = new ToolStripSeparator();
            toolStripButton9 = new ToolStripButton();
            groupBox2 = new GroupBox();
            propertiesPanel1 = new PropertiesPanel();
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox1.SuspendLayout();
            toolStrip2.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, редактироватьToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1039, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, сохранитьToolStripMenuItem, saveToolStripMenuItem, сохранитьКакToolStripMenuItem1, toolStripSeparator1, экспортироватьToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(48, 20);
            fileToolStripMenuItem.Text = "Файл";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newErSchemaItem, eRдиаграммаToolStripMenuItem1, элементToolStripMenuItem });
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(180, 22);
            newToolStripMenuItem.Text = "Создать";
            // 
            // newErSchemaItem
            // 
            newErSchemaItem.Name = "newErSchemaItem";
            newErSchemaItem.Size = new Size(153, 22);
            newErSchemaItem.Text = "ER-схему";
            newErSchemaItem.Click += newErSchemaItem_Click;
            // 
            // eRдиаграммаToolStripMenuItem1
            // 
            eRдиаграммаToolStripMenuItem1.Enabled = false;
            eRдиаграммаToolStripMenuItem1.Name = "eRдиаграммаToolStripMenuItem1";
            eRдиаграммаToolStripMenuItem1.Size = new Size(153, 22);
            eRдиаграммаToolStripMenuItem1.Text = "ER-диаграмму";
            // 
            // элементToolStripMenuItem
            // 
            элементToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { множествоСущностейToolStripMenuItem, множествоСвязейToolStripMenuItem, множествоЗначенийToolStripMenuItem });
            элементToolStripMenuItem.Enabled = false;
            элементToolStripMenuItem.Name = "элементToolStripMenuItem";
            элементToolStripMenuItem.Size = new Size(153, 22);
            элементToolStripMenuItem.Text = "Элемент...";
            // 
            // множествоСущностейToolStripMenuItem
            // 
            множествоСущностейToolStripMenuItem.Name = "множествоСущностейToolStripMenuItem";
            множествоСущностейToolStripMenuItem.Size = new Size(202, 22);
            множествоСущностейToolStripMenuItem.Text = "Множество сущностей";
            // 
            // множествоСвязейToolStripMenuItem
            // 
            множествоСвязейToolStripMenuItem.Name = "множествоСвязейToolStripMenuItem";
            множествоСвязейToolStripMenuItem.Size = new Size(202, 22);
            множествоСвязейToolStripMenuItem.Text = "Множество связей";
            // 
            // множествоЗначенийToolStripMenuItem
            // 
            множествоЗначенийToolStripMenuItem.Name = "множествоЗначенийToolStripMenuItem";
            множествоЗначенийToolStripMenuItem.Size = new Size(202, 22);
            множествоЗначенийToolStripMenuItem.Text = "Множество значений";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openErSchemaItem });
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(180, 22);
            openToolStripMenuItem.Text = "Открыть";
            // 
            // openErSchemaItem
            // 
            openErSchemaItem.Name = "openErSchemaItem";
            openErSchemaItem.Size = new Size(125, 22);
            openErSchemaItem.Text = "ER-схему";
            openErSchemaItem.Click += openErSchemaItem_Click;
            // 
            // сохранитьToolStripMenuItem
            // 
            сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            сохранитьToolStripMenuItem.Size = new Size(177, 6);
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(180, 22);
            saveToolStripMenuItem.Text = "Сохранить";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // сохранитьКакToolStripMenuItem1
            // 
            сохранитьКакToolStripMenuItem1.Enabled = false;
            сохранитьКакToolStripMenuItem1.Name = "сохранитьКакToolStripMenuItem1";
            сохранитьКакToolStripMenuItem1.Size = new Size(180, 22);
            сохранитьКакToolStripMenuItem1.Text = "Сохранить как...";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(177, 6);
            // 
            // экспортироватьToolStripMenuItem
            // 
            экспортироватьToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { eRсхемуToolStripMenuItem1, eRдиаграммуToolStripMenuItem });
            экспортироватьToolStripMenuItem.Enabled = false;
            экспортироватьToolStripMenuItem.Name = "экспортироватьToolStripMenuItem";
            экспортироватьToolStripMenuItem.Size = new Size(180, 22);
            экспортироватьToolStripMenuItem.Text = "Экспортировать";
            // 
            // eRсхемуToolStripMenuItem1
            // 
            eRсхемуToolStripMenuItem1.Name = "eRсхемуToolStripMenuItem1";
            eRсхемуToolStripMenuItem1.Size = new Size(153, 22);
            eRсхемуToolStripMenuItem1.Text = "ER-схему";
            // 
            // eRдиаграммуToolStripMenuItem
            // 
            eRдиаграммуToolStripMenuItem.Name = "eRдиаграммуToolStripMenuItem";
            eRдиаграммуToolStripMenuItem.Size = new Size(153, 22);
            eRдиаграммуToolStripMenuItem.Text = "ER-диаграмму";
            // 
            // редактироватьToolStripMenuItem
            // 
            редактироватьToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { копироватьToolStripMenuItem, вставитьToolStripMenuItem, дубликатToolStripMenuItem, toolStripSeparator4, удалитьToolStripMenuItem });
            редактироватьToolStripMenuItem.Enabled = false;
            редактироватьToolStripMenuItem.Name = "редактироватьToolStripMenuItem";
            редактироватьToolStripMenuItem.Size = new Size(59, 20);
            редактироватьToolStripMenuItem.Text = "Правка";
            // 
            // копироватьToolStripMenuItem
            // 
            копироватьToolStripMenuItem.Name = "копироватьToolStripMenuItem";
            копироватьToolStripMenuItem.Size = new Size(139, 22);
            копироватьToolStripMenuItem.Text = "Копировать";
            // 
            // вставитьToolStripMenuItem
            // 
            вставитьToolStripMenuItem.Name = "вставитьToolStripMenuItem";
            вставитьToolStripMenuItem.Size = new Size(139, 22);
            вставитьToolStripMenuItem.Text = "Вставить";
            // 
            // дубликатToolStripMenuItem
            // 
            дубликатToolStripMenuItem.Name = "дубликатToolStripMenuItem";
            дубликатToolStripMenuItem.Size = new Size(139, 22);
            дубликатToolStripMenuItem.Text = "Дубликат";
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(136, 6);
            // 
            // удалитьToolStripMenuItem
            // 
            удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            удалитьToolStripMenuItem.Size = new Size(139, 22);
            удалитьToolStripMenuItem.Text = "Удалить";
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripSplitButton1, toolStripButton2 });
            toolStrip1.Location = new Point(0, 24);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1039, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.DropDownItems.AddRange(new ToolStripItem[] { eRДиаграммаToolStripMenuItem3, eRToolStripMenuItem, элементToolStripMenuItem1 });
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(32, 22);
            toolStripButton1.Text = "toolStripButton1";
            // 
            // eRДиаграммаToolStripMenuItem3
            // 
            eRДиаграммаToolStripMenuItem3.Name = "eRДиаграммаToolStripMenuItem3";
            eRДиаграммаToolStripMenuItem3.Size = new Size(153, 22);
            eRДиаграммаToolStripMenuItem3.Text = "ER-схема";
            // 
            // eRToolStripMenuItem
            // 
            eRToolStripMenuItem.Name = "eRToolStripMenuItem";
            eRToolStripMenuItem.Size = new Size(153, 22);
            eRToolStripMenuItem.Text = "ER-диаграмма";
            // 
            // элементToolStripMenuItem1
            // 
            элементToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { множествоСущностейToolStripMenuItem1, множествоСвязейToolStripMenuItem1, множествоЗначенийToolStripMenuItem1 });
            элементToolStripMenuItem1.Name = "элементToolStripMenuItem1";
            элементToolStripMenuItem1.Size = new Size(153, 22);
            элементToolStripMenuItem1.Text = "Элемент...";
            // 
            // множествоСущностейToolStripMenuItem1
            // 
            множествоСущностейToolStripMenuItem1.Name = "множествоСущностейToolStripMenuItem1";
            множествоСущностейToolStripMenuItem1.Size = new Size(202, 22);
            множествоСущностейToolStripMenuItem1.Text = "Множество сущностей";
            // 
            // множествоСвязейToolStripMenuItem1
            // 
            множествоСвязейToolStripMenuItem1.Name = "множествоСвязейToolStripMenuItem1";
            множествоСвязейToolStripMenuItem1.Size = new Size(202, 22);
            множествоСвязейToolStripMenuItem1.Text = "Множество связей";
            // 
            // множествоЗначенийToolStripMenuItem1
            // 
            множествоЗначенийToolStripMenuItem1.Name = "множествоЗначенийToolStripMenuItem1";
            множествоЗначенийToolStripMenuItem1.Size = new Size(202, 22);
            множествоЗначенийToolStripMenuItem1.Text = "Множество значений";
            // 
            // toolStripSplitButton1
            // 
            toolStripSplitButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripSplitButton1.DropDownItems.AddRange(new ToolStripItem[] { eRсхемаToolStripMenuItem });
            toolStripSplitButton1.Image = (Image)resources.GetObject("toolStripSplitButton1.Image");
            toolStripSplitButton1.ImageTransparentColor = Color.Magenta;
            toolStripSplitButton1.Name = "toolStripSplitButton1";
            toolStripSplitButton1.Size = new Size(32, 22);
            toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // eRсхемаToolStripMenuItem
            // 
            eRсхемаToolStripMenuItem.Name = "eRсхемаToolStripMenuItem";
            eRсхемаToolStripMenuItem.Size = new Size(125, 22);
            eRсхемаToolStripMenuItem.Text = "ER-схема";
            // 
            // toolStripButton2
            // 
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton2.Enabled = false;
            toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(23, 22);
            toolStripButton2.Text = "toolStripButton2";
            // 
            // splitContainer1
            // 
            splitContainer1.BorderStyle = BorderStyle.Fixed3D;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 49);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBox2);
            splitContainer1.Size = new Size(1039, 507);
            splitContainer1.SplitterDistance = 345;
            splitContainer1.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(navigatorPanel1);
            groupBox1.Controls.Add(toolStrip2);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Enabled = false;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(341, 503);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Навигатор";
            // 
            // navigatorPanel1
            // 
            navigatorPanel1.Dock = DockStyle.Fill;
            navigatorPanel1.ImageIndex = 0;
            navigatorPanel1.Location = new Point(27, 19);
            navigatorPanel1.Name = "navigatorPanel1";
            navigatorPanel1.SelectedImageIndex = 0;
            navigatorPanel1.Size = new Size(311, 481);
            navigatorPanel1.TabIndex = 1;
            // 
            // toolStrip2
            // 
            toolStrip2.Dock = DockStyle.Left;
            toolStrip2.Items.AddRange(new ToolStripItem[] { toolStripButton10, toolStripButton3, toolStripButton4, toolStripButton5, toolStripSeparator2, toolStripButton6, toolStripButton7, toolStripSeparator3, toolStripButton8, toolStripButton9 });
            toolStrip2.Location = new Point(3, 19);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(24, 481);
            toolStrip2.TabIndex = 0;
            toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton10
            // 
            toolStripButton10.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton10.Image = (Image)resources.GetObject("toolStripButton10.Image");
            toolStripButton10.ImageTransparentColor = Color.Magenta;
            toolStripButton10.Name = "toolStripButton10";
            toolStripButton10.Size = new Size(21, 20);
            toolStripButton10.Text = "toolStripButton10";
            // 
            // toolStripButton3
            // 
            toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton3.Image = (Image)resources.GetObject("toolStripButton3.Image");
            toolStripButton3.ImageTransparentColor = Color.Magenta;
            toolStripButton3.Name = "toolStripButton3";
            toolStripButton3.Size = new Size(21, 20);
            toolStripButton3.Text = "toolStripButton3";
            // 
            // toolStripButton4
            // 
            toolStripButton4.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton4.Image = (Image)resources.GetObject("toolStripButton4.Image");
            toolStripButton4.ImageTransparentColor = Color.Magenta;
            toolStripButton4.Name = "toolStripButton4";
            toolStripButton4.Size = new Size(21, 20);
            toolStripButton4.Text = "toolStripButton4";
            // 
            // toolStripButton5
            // 
            toolStripButton5.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton5.Image = (Image)resources.GetObject("toolStripButton5.Image");
            toolStripButton5.ImageTransparentColor = Color.Magenta;
            toolStripButton5.Name = "toolStripButton5";
            toolStripButton5.Size = new Size(21, 20);
            toolStripButton5.Text = "toolStripButton5";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(21, 6);
            // 
            // toolStripButton6
            // 
            toolStripButton6.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton6.Image = (Image)resources.GetObject("toolStripButton6.Image");
            toolStripButton6.ImageTransparentColor = Color.Magenta;
            toolStripButton6.Name = "toolStripButton6";
            toolStripButton6.Size = new Size(21, 20);
            toolStripButton6.Text = "toolStripButton6";
            // 
            // toolStripButton7
            // 
            toolStripButton7.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton7.Image = (Image)resources.GetObject("toolStripButton7.Image");
            toolStripButton7.ImageTransparentColor = Color.Magenta;
            toolStripButton7.Name = "toolStripButton7";
            toolStripButton7.Size = new Size(21, 20);
            toolStripButton7.Text = "toolStripButton7";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripSeparator3.Image = (Image)resources.GetObject("toolStripSeparator3.Image");
            toolStripSeparator3.ImageTransparentColor = Color.Magenta;
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(21, 20);
            // 
            // toolStripButton8
            // 
            toolStripButton8.Name = "toolStripButton8";
            toolStripButton8.Size = new Size(21, 6);
            // 
            // toolStripButton9
            // 
            toolStripButton9.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton9.Image = (Image)resources.GetObject("toolStripButton9.Image");
            toolStripButton9.ImageTransparentColor = Color.Magenta;
            toolStripButton9.Name = "toolStripButton9";
            toolStripButton9.Size = new Size(21, 20);
            toolStripButton9.Text = "toolStripButton9";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(propertiesPanel1);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Enabled = false;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(686, 503);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Свойства элемента";
            // 
            // propertiesPanel1
            // 
            propertiesPanel1.Dock = DockStyle.Fill;
            propertiesPanel1.Location = new Point(3, 19);
            propertiesPanel1.Name = "propertiesPanel1";
            propertiesPanel1.Size = new Size(680, 481);
            propertiesPanel1.TabIndex = 0;
            // 
            // ErEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1039, 556);
            Controls.Add(splitContainer1);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "ErEditor";
            Text = "Редактор ER-схем";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem newErSchemaItem;
        private ToolStripMenuItem eRдиаграммаToolStripMenuItem1;
        private ToolStripMenuItem элементToolStripMenuItem;
        private ToolStripMenuItem множествоСущностейToolStripMenuItem;
        private ToolStripMenuItem множествоСвязейToolStripMenuItem;
        private ToolStripMenuItem множествоЗначенийToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem openErSchemaItem;
        private ToolStrip toolStrip1;
        private ToolStripSeparator сохранитьToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem сохранитьКакToolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem экспортироватьToolStripMenuItem;
        private ToolStripMenuItem eRсхемуToolStripMenuItem1;
        private ToolStripMenuItem eRдиаграммуToolStripMenuItem;
        private ToolStripSplitButton toolStripButton1;
        private ToolStripSplitButton toolStripSplitButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripMenuItem eRДиаграммаToolStripMenuItem3;
        private ToolStripMenuItem eRToolStripMenuItem;
        private ToolStripMenuItem элементToolStripMenuItem1;
        private ToolStripMenuItem множествоСущностейToolStripMenuItem1;
        private ToolStripMenuItem множествоСвязейToolStripMenuItem1;
        private ToolStripMenuItem множествоЗначенийToolStripMenuItem1;
        private ToolStripMenuItem eRсхемаToolStripMenuItem;
        private SplitContainer splitContainer1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private ToolStrip toolStrip2;
        private ToolStripButton toolStripButton3;
        private ToolStripButton toolStripButton4;
        private ToolStripButton toolStripButton5;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton toolStripButton6;
        private ToolStripButton toolStripButton7;
        private ToolStripButton toolStripSeparator3;
        private ToolStripSeparator toolStripButton8;
        private ToolStripButton toolStripButton9;
        private ToolStripMenuItem редактироватьToolStripMenuItem;
        private ToolStripMenuItem копироватьToolStripMenuItem;
        private ToolStripMenuItem вставитьToolStripMenuItem;
        private ToolStripMenuItem дубликатToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem удалитьToolStripMenuItem;
        private ToolStripButton toolStripButton10;
        private PropertiesPanel propertiesPanel1;
        private NavigatorTree navigatorPanel1;
    }
}
