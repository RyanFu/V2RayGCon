﻿namespace Luna.Views.WinForms
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbStatusBarMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkEnableClrSupports = new System.Windows.Forms.CheckBox();
            this.btnExportToFile = new System.Windows.Forms.Button();
            this.btnImportFromFile = new System.Windows.Forms.Button();
            this.btnDeleteAllScripts = new System.Windows.Forms.Button();
            this.btnStopAllScript = new System.Windows.Forms.Button();
            this.btnKillAllScript = new System.Windows.Forms.Button();
            this.flyScriptUIContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.tabEditor = new System.Windows.Forms.TabPage();
            this.splitContainerTabEditor = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelScriptName = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cboxScriptName = new System.Windows.Forms.ComboBox();
            this.btnNewScript = new System.Windows.Forms.Button();
            this.btnSaveScript = new System.Windows.Forms.Button();
            this.pnlScriptEditor = new System.Windows.Forms.Panel();
            this.panelScriptDebugTools = new System.Windows.Forms.Panel();
            this.cboxFunctionList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnKillScript = new System.Windows.Forms.Button();
            this.btnClearOutput = new System.Windows.Forms.Button();
            this.btnStopScript = new System.Windows.Forms.Button();
            this.btnRunScript = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtBoxOutput = new VgcApis.UserControls.ExRichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.loadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showOutputPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideOutputPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTabEditor)).BeginInit();
            this.splitContainerTabEditor.Panel1.SuspendLayout();
            this.splitContainerTabEditor.Panel2.SuspendLayout();
            this.splitContainerTabEditor.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelScriptName.SuspendLayout();
            this.panelScriptDebugTools.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tabControl1);
            resources.ApplyResources(this.toolStripContainer1.ContentPanel, "toolStripContainer1.ContentPanel");
            resources.ApplyResources(this.toolStripContainer1, "toolStripContainer1");
            this.toolStripContainer1.Name = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
            // 
            // statusStrip1
            // 
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbStatusBarMsg});
            this.statusStrip1.Name = "statusStrip1";
            // 
            // lbStatusBarMsg
            // 
            this.lbStatusBarMsg.Name = "lbStatusBarMsg";
            resources.ApplyResources(this.lbStatusBarMsg, "lbStatusBarMsg");
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabGeneral);
            this.tabControl1.Controls.Add(this.tabEditor);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.panel2);
            this.tabGeneral.Controls.Add(this.flyScriptUIContainer);
            resources.ApplyResources(this.tabGeneral, "tabGeneral");
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.chkEnableClrSupports);
            this.panel2.Controls.Add(this.btnExportToFile);
            this.panel2.Controls.Add(this.btnImportFromFile);
            this.panel2.Controls.Add(this.btnDeleteAllScripts);
            this.panel2.Controls.Add(this.btnStopAllScript);
            this.panel2.Controls.Add(this.btnKillAllScript);
            this.panel2.Name = "panel2";
            // 
            // chkEnableClrSupports
            // 
            resources.ApplyResources(this.chkEnableClrSupports, "chkEnableClrSupports");
            this.chkEnableClrSupports.Name = "chkEnableClrSupports";
            this.toolTip1.SetToolTip(this.chkEnableClrSupports, resources.GetString("chkEnableClrSupports.ToolTip"));
            this.chkEnableClrSupports.UseVisualStyleBackColor = true;
            this.chkEnableClrSupports.CheckedChanged += new System.EventHandler(this.chkEnableClrSupports_CheckedChanged);
            // 
            // btnExportToFile
            // 
            resources.ApplyResources(this.btnExportToFile, "btnExportToFile");
            this.btnExportToFile.Name = "btnExportToFile";
            this.toolTip1.SetToolTip(this.btnExportToFile, resources.GetString("btnExportToFile.ToolTip"));
            this.btnExportToFile.UseVisualStyleBackColor = true;
            // 
            // btnImportFromFile
            // 
            resources.ApplyResources(this.btnImportFromFile, "btnImportFromFile");
            this.btnImportFromFile.Name = "btnImportFromFile";
            this.toolTip1.SetToolTip(this.btnImportFromFile, resources.GetString("btnImportFromFile.ToolTip"));
            this.btnImportFromFile.UseVisualStyleBackColor = true;
            // 
            // btnDeleteAllScripts
            // 
            resources.ApplyResources(this.btnDeleteAllScripts, "btnDeleteAllScripts");
            this.btnDeleteAllScripts.Name = "btnDeleteAllScripts";
            this.toolTip1.SetToolTip(this.btnDeleteAllScripts, resources.GetString("btnDeleteAllScripts.ToolTip"));
            this.btnDeleteAllScripts.UseVisualStyleBackColor = true;
            // 
            // btnStopAllScript
            // 
            resources.ApplyResources(this.btnStopAllScript, "btnStopAllScript");
            this.btnStopAllScript.Name = "btnStopAllScript";
            this.toolTip1.SetToolTip(this.btnStopAllScript, resources.GetString("btnStopAllScript.ToolTip"));
            this.btnStopAllScript.UseVisualStyleBackColor = true;
            // 
            // btnKillAllScript
            // 
            resources.ApplyResources(this.btnKillAllScript, "btnKillAllScript");
            this.btnKillAllScript.Name = "btnKillAllScript";
            this.toolTip1.SetToolTip(this.btnKillAllScript, resources.GetString("btnKillAllScript.ToolTip"));
            this.btnKillAllScript.UseVisualStyleBackColor = true;
            // 
            // flyScriptUIContainer
            // 
            this.flyScriptUIContainer.AllowDrop = true;
            resources.ApplyResources(this.flyScriptUIContainer, "flyScriptUIContainer");
            this.flyScriptUIContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flyScriptUIContainer.Name = "flyScriptUIContainer";
            this.flyScriptUIContainer.Scroll += new System.Windows.Forms.ScrollEventHandler(this.flyScriptUIContainer_Scroll);
            // 
            // tabEditor
            // 
            this.tabEditor.Controls.Add(this.splitContainerTabEditor);
            resources.ApplyResources(this.tabEditor, "tabEditor");
            this.tabEditor.Name = "tabEditor";
            this.tabEditor.UseVisualStyleBackColor = true;
            // 
            // splitContainerTabEditor
            // 
            resources.ApplyResources(this.splitContainerTabEditor, "splitContainerTabEditor");
            this.splitContainerTabEditor.Name = "splitContainerTabEditor";
            // 
            // splitContainerTabEditor.Panel1
            // 
            this.splitContainerTabEditor.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainerTabEditor.Panel2
            // 
            this.splitContainerTabEditor.Panel2.Controls.Add(this.groupBox1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel3);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tableLayoutPanel1);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.panelScriptName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlScriptEditor, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panelScriptDebugTools, 0, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // panelScriptName
            // 
            this.panelScriptName.Controls.Add(this.label1);
            this.panelScriptName.Controls.Add(this.cboxScriptName);
            this.panelScriptName.Controls.Add(this.btnNewScript);
            this.panelScriptName.Controls.Add(this.btnSaveScript);
            resources.ApplyResources(this.panelScriptName, "panelScriptName");
            this.panelScriptName.Name = "panelScriptName";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.toolTip1.SetToolTip(this.label1, resources.GetString("label1.ToolTip"));
            // 
            // cboxScriptName
            // 
            resources.ApplyResources(this.cboxScriptName, "cboxScriptName");
            this.cboxScriptName.FormattingEnabled = true;
            this.cboxScriptName.Name = "cboxScriptName";
            this.toolTip1.SetToolTip(this.cboxScriptName, resources.GetString("cboxScriptName.ToolTip"));
            // 
            // btnNewScript
            // 
            resources.ApplyResources(this.btnNewScript, "btnNewScript");
            this.btnNewScript.Name = "btnNewScript";
            this.toolTip1.SetToolTip(this.btnNewScript, resources.GetString("btnNewScript.ToolTip"));
            this.btnNewScript.UseVisualStyleBackColor = true;
            // 
            // btnSaveScript
            // 
            resources.ApplyResources(this.btnSaveScript, "btnSaveScript");
            this.btnSaveScript.Name = "btnSaveScript";
            this.toolTip1.SetToolTip(this.btnSaveScript, resources.GetString("btnSaveScript.ToolTip"));
            this.btnSaveScript.UseVisualStyleBackColor = true;
            // 
            // pnlScriptEditor
            // 
            resources.ApplyResources(this.pnlScriptEditor, "pnlScriptEditor");
            this.pnlScriptEditor.Name = "pnlScriptEditor";
            // 
            // panelScriptDebugTools
            // 
            this.panelScriptDebugTools.Controls.Add(this.cboxFunctionList);
            this.panelScriptDebugTools.Controls.Add(this.label2);
            this.panelScriptDebugTools.Controls.Add(this.btnKillScript);
            this.panelScriptDebugTools.Controls.Add(this.btnClearOutput);
            this.panelScriptDebugTools.Controls.Add(this.btnStopScript);
            this.panelScriptDebugTools.Controls.Add(this.btnRunScript);
            resources.ApplyResources(this.panelScriptDebugTools, "panelScriptDebugTools");
            this.panelScriptDebugTools.Name = "panelScriptDebugTools";
            // 
            // cboxFunctionList
            // 
            resources.ApplyResources(this.cboxFunctionList, "cboxFunctionList");
            this.cboxFunctionList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxFunctionList.FormattingEnabled = true;
            this.cboxFunctionList.Name = "cboxFunctionList";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            this.toolTip1.SetToolTip(this.label2, resources.GetString("label2.ToolTip"));
            // 
            // btnKillScript
            // 
            resources.ApplyResources(this.btnKillScript, "btnKillScript");
            this.btnKillScript.Name = "btnKillScript";
            this.toolTip1.SetToolTip(this.btnKillScript, resources.GetString("btnKillScript.ToolTip"));
            this.btnKillScript.UseVisualStyleBackColor = true;
            // 
            // btnClearOutput
            // 
            resources.ApplyResources(this.btnClearOutput, "btnClearOutput");
            this.btnClearOutput.Name = "btnClearOutput";
            this.toolTip1.SetToolTip(this.btnClearOutput, resources.GetString("btnClearOutput.ToolTip"));
            this.btnClearOutput.UseVisualStyleBackColor = true;
            // 
            // btnStopScript
            // 
            resources.ApplyResources(this.btnStopScript, "btnStopScript");
            this.btnStopScript.Name = "btnStopScript";
            this.toolTip1.SetToolTip(this.btnStopScript, resources.GetString("btnStopScript.ToolTip"));
            this.btnStopScript.UseVisualStyleBackColor = true;
            // 
            // btnRunScript
            // 
            resources.ApplyResources(this.btnRunScript, "btnRunScript");
            this.btnRunScript.Name = "btnRunScript";
            this.toolTip1.SetToolTip(this.btnRunScript, resources.GetString("btnRunScript.ToolTip"));
            this.btnRunScript.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtBoxOutput);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // rtBoxOutput
            // 
            this.rtBoxOutput.BackColor = System.Drawing.SystemColors.Control;
            this.rtBoxOutput.DetectUrls = false;
            resources.ApplyResources(this.rtBoxOutput, "rtBoxOutput");
            this.rtBoxOutput.Name = "rtBoxOutput";
            this.rtBoxOutput.ReadOnly = true;
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newWindowToolStripMenuItem,
            this.toolStripSeparator1,
            this.loadFileToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // newWindowToolStripMenuItem
            // 
            this.newWindowToolStripMenuItem.Name = "newWindowToolStripMenuItem";
            resources.ApplyResources(this.newWindowToolStripMenuItem, "newWindowToolStripMenuItem");
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // loadFileToolStripMenuItem
            // 
            this.loadFileToolStripMenuItem.Name = "loadFileToolStripMenuItem";
            resources.ApplyResources(this.loadFileToolStripMenuItem, "loadFileToolStripMenuItem");
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            resources.ApplyResources(this.saveAsToolStripMenuItem, "saveAsToolStripMenuItem");
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showOutputPanelToolStripMenuItem,
            this.hideOutputPanelToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            resources.ApplyResources(this.viewToolStripMenuItem, "viewToolStripMenuItem");
            // 
            // showOutputPanelToolStripMenuItem
            // 
            this.showOutputPanelToolStripMenuItem.Name = "showOutputPanelToolStripMenuItem";
            resources.ApplyResources(this.showOutputPanelToolStripMenuItem, "showOutputPanelToolStripMenuItem");
            this.showOutputPanelToolStripMenuItem.Click += new System.EventHandler(this.showOutputPanelToolStripMenuItem_Click);
            // 
            // hideOutputPanelToolStripMenuItem
            // 
            this.hideOutputPanelToolStripMenuItem.Name = "hideOutputPanelToolStripMenuItem";
            resources.ApplyResources(this.hideOutputPanelToolStripMenuItem, "hideOutputPanelToolStripMenuItem");
            this.hideOutputPanelToolStripMenuItem.Click += new System.EventHandler(this.hideOutputPanelToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabEditor.ResumeLayout(false);
            this.splitContainerTabEditor.Panel1.ResumeLayout(false);
            this.splitContainerTabEditor.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTabEditor)).EndInit();
            this.splitContainerTabEditor.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panelScriptName.ResumeLayout(false);
            this.panelScriptName.PerformLayout();
            this.panelScriptDebugTools.ResumeLayout(false);
            this.panelScriptDebugTools.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbStatusBarMsg;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.Button btnKillAllScript;
        private System.Windows.Forms.Button btnStopAllScript;
        private System.Windows.Forms.FlowLayoutPanel flyScriptUIContainer;
        private System.Windows.Forms.TabPage tabEditor;
        private System.Windows.Forms.SplitContainer splitContainerTabEditor;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelScriptName;
        private System.Windows.Forms.ComboBox cboxScriptName;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnKillScript;
        private System.Windows.Forms.Button btnStopScript;
        private System.Windows.Forms.Button btnRunScript;
        private System.Windows.Forms.Button btnSaveScript;
        private System.Windows.Forms.Panel pnlScriptEditor;
        private System.Windows.Forms.GroupBox groupBox1;
        private VgcApis.UserControls.ExRichTextBox rtBoxOutput;
        private System.Windows.Forms.Button btnClearOutput;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnNewScript;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnExportToFile;
        private System.Windows.Forms.Button btnImportFromFile;
        private System.Windows.Forms.Button btnDeleteAllScripts;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showOutputPanelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideOutputPanelToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkEnableClrSupports;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelScriptDebugTools;
        private System.Windows.Forms.ComboBox cboxFunctionList;
        private System.Windows.Forms.Label label2;
    }
}
