namespace DemoWF
{
    partial class FrmMain
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnCacheAll = new System.Windows.Forms.Button();
            this.btnGetAll = new System.Windows.Forms.Button();
            this.btnGetById = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabRedisServiceStack = new System.Windows.Forms.TabPage();
            this.tabRedisStackExchange = new System.Windows.Forms.TabPage();
            this.btnDecrement = new System.Windows.Forms.Button();
            this.lblCounter = new System.Windows.Forms.Label();
            this.btnIncr = new System.Windows.Forms.Button();
            this.txtIdSEx = new System.Windows.Forms.TextBox();
            this.btnGetByIdSEx = new System.Windows.Forms.Button();
            this.btnGetAllBySEx = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabMember = new System.Windows.Forms.TabPage();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemoveMember = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabRedisServiceStack.SuspendLayout();
            this.tabRedisStackExchange.SuspendLayout();
            this.tabMember.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 196);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(615, 264);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnCacheAll
            // 
            this.btnCacheAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCacheAll.Location = new System.Drawing.Point(7, 11);
            this.btnCacheAll.Name = "btnCacheAll";
            this.btnCacheAll.Size = new System.Drawing.Size(124, 47);
            this.btnCacheAll.TabIndex = 1;
            this.btnCacheAll.Text = "Cache All";
            this.btnCacheAll.UseVisualStyleBackColor = true;
            this.btnCacheAll.Click += new System.EventHandler(this.btnCacheAll_Click);
            // 
            // btnGetAll
            // 
            this.btnGetAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetAll.Location = new System.Drawing.Point(148, 11);
            this.btnGetAll.Name = "btnGetAll";
            this.btnGetAll.Size = new System.Drawing.Size(124, 47);
            this.btnGetAll.TabIndex = 2;
            this.btnGetAll.Text = "Get All";
            this.btnGetAll.UseVisualStyleBackColor = true;
            // 
            // btnGetById
            // 
            this.btnGetById.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetById.Location = new System.Drawing.Point(148, 74);
            this.btnGetById.Name = "btnGetById";
            this.btnGetById.Size = new System.Drawing.Size(124, 47);
            this.btnGetById.TabIndex = 3;
            this.btnGetById.Text = "Get By Id";
            this.btnGetById.UseVisualStyleBackColor = true;
            // 
            // txtId
            // 
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtId.Location = new System.Drawing.Point(7, 80);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(124, 30);
            this.txtId.TabIndex = 4;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabRedisServiceStack);
            this.tabControl.Controls.Add(this.tabRedisStackExchange);
            this.tabControl.Controls.Add(this.tabMember);
            this.tabControl.Location = new System.Drawing.Point(4, 2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(633, 188);
            this.tabControl.TabIndex = 5;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_TabIndexChanged);
            // 
            // tabRedisServiceStack
            // 
            this.tabRedisServiceStack.Controls.Add(this.txtId);
            this.tabRedisServiceStack.Controls.Add(this.btnCacheAll);
            this.tabRedisServiceStack.Controls.Add(this.btnGetById);
            this.tabRedisServiceStack.Controls.Add(this.btnGetAll);
            this.tabRedisServiceStack.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.tabRedisServiceStack.Location = new System.Drawing.Point(4, 22);
            this.tabRedisServiceStack.Name = "tabRedisServiceStack";
            this.tabRedisServiceStack.Padding = new System.Windows.Forms.Padding(3);
            this.tabRedisServiceStack.Size = new System.Drawing.Size(625, 162);
            this.tabRedisServiceStack.TabIndex = 0;
            this.tabRedisServiceStack.Text = "Service Stack";
            this.tabRedisServiceStack.UseVisualStyleBackColor = true;
            // 
            // tabRedisStackExchange
            // 
            this.tabRedisStackExchange.Controls.Add(this.btnDecrement);
            this.tabRedisStackExchange.Controls.Add(this.lblCounter);
            this.tabRedisStackExchange.Controls.Add(this.btnIncr);
            this.tabRedisStackExchange.Controls.Add(this.txtIdSEx);
            this.tabRedisStackExchange.Controls.Add(this.btnGetByIdSEx);
            this.tabRedisStackExchange.Controls.Add(this.btnGetAllBySEx);
            this.tabRedisStackExchange.Controls.Add(this.button1);
            this.tabRedisStackExchange.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabRedisStackExchange.Location = new System.Drawing.Point(4, 22);
            this.tabRedisStackExchange.Name = "tabRedisStackExchange";
            this.tabRedisStackExchange.Padding = new System.Windows.Forms.Padding(3);
            this.tabRedisStackExchange.Size = new System.Drawing.Size(625, 162);
            this.tabRedisStackExchange.TabIndex = 1;
            this.tabRedisStackExchange.Text = "Stack Exchange";
            this.tabRedisStackExchange.UseVisualStyleBackColor = true;
            // 
            // btnDecrement
            // 
            this.btnDecrement.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecrement.Location = new System.Drawing.Point(457, 74);
            this.btnDecrement.Name = "btnDecrement";
            this.btnDecrement.Size = new System.Drawing.Size(88, 47);
            this.btnDecrement.TabIndex = 10;
            this.btnDecrement.Text = "Decr";
            this.btnDecrement.UseVisualStyleBackColor = true;
            this.btnDecrement.Click += new System.EventHandler(this.btnDecrement_Click);
            // 
            // lblCounter
            // 
            this.lblCounter.AutoSize = true;
            this.lblCounter.Location = new System.Drawing.Point(400, 84);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(20, 24);
            this.lblCounter.TabIndex = 9;
            this.lblCounter.Text = "0";
            // 
            // btnIncr
            // 
            this.btnIncr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncr.Location = new System.Drawing.Point(306, 74);
            this.btnIncr.Name = "btnIncr";
            this.btnIncr.Size = new System.Drawing.Size(88, 47);
            this.btnIncr.TabIndex = 8;
            this.btnIncr.Text = "Incr";
            this.btnIncr.UseVisualStyleBackColor = true;
            this.btnIncr.Click += new System.EventHandler(this.btnIncr_Click);
            // 
            // txtIdSEx
            // 
            this.txtIdSEx.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtIdSEx.Location = new System.Drawing.Point(7, 80);
            this.txtIdSEx.Name = "txtIdSEx";
            this.txtIdSEx.Size = new System.Drawing.Size(124, 30);
            this.txtIdSEx.TabIndex = 7;
            // 
            // btnGetByIdSEx
            // 
            this.btnGetByIdSEx.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetByIdSEx.Location = new System.Drawing.Point(148, 74);
            this.btnGetByIdSEx.Name = "btnGetByIdSEx";
            this.btnGetByIdSEx.Size = new System.Drawing.Size(124, 47);
            this.btnGetByIdSEx.TabIndex = 6;
            this.btnGetByIdSEx.Text = "Get By Id";
            this.btnGetByIdSEx.UseVisualStyleBackColor = true;
            // 
            // btnGetAllBySEx
            // 
            this.btnGetAllBySEx.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetAllBySEx.Location = new System.Drawing.Point(148, 11);
            this.btnGetAllBySEx.Name = "btnGetAllBySEx";
            this.btnGetAllBySEx.Size = new System.Drawing.Size(124, 47);
            this.btnGetAllBySEx.TabIndex = 5;
            this.btnGetAllBySEx.Text = "Get All";
            this.btnGetAllBySEx.UseVisualStyleBackColor = true;
            this.btnGetAllBySEx.Click += new System.EventHandler(this.btnGetAllBySEx_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(7, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 47);
            this.button1.TabIndex = 2;
            this.button1.Text = "Cache All";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabMember
            // 
            this.tabMember.Controls.Add(this.btnRemoveMember);
            this.tabMember.Controls.Add(this.btnAdd);
            this.tabMember.Location = new System.Drawing.Point(4, 22);
            this.tabMember.Name = "tabMember";
            this.tabMember.Padding = new System.Windows.Forms.Padding(3);
            this.tabMember.Size = new System.Drawing.Size(625, 162);
            this.tabMember.TabIndex = 2;
            this.tabMember.Text = "Member";
            this.tabMember.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(6, 17);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(150, 47);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemoveMember
            // 
            this.btnRemoveMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveMember.Location = new System.Drawing.Point(183, 17);
            this.btnRemoveMember.Name = "btnRemoveMember";
            this.btnRemoveMember.Size = new System.Drawing.Size(150, 47);
            this.btnRemoveMember.TabIndex = 10;
            this.btnRemoveMember.Text = "Remove";
            this.btnRemoveMember.UseVisualStyleBackColor = true;
            this.btnRemoveMember.Click += new System.EventHandler(this.btnRemoveMember_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 463);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FrmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabRedisServiceStack.ResumeLayout(false);
            this.tabRedisServiceStack.PerformLayout();
            this.tabRedisStackExchange.ResumeLayout(false);
            this.tabRedisStackExchange.PerformLayout();
            this.tabMember.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnCacheAll;
        private System.Windows.Forms.Button btnGetAll;
        private System.Windows.Forms.Button btnGetById;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabRedisServiceStack;
        private System.Windows.Forms.TabPage tabRedisStackExchange;
        private System.Windows.Forms.TextBox txtIdSEx;
        private System.Windows.Forms.Button btnGetByIdSEx;
        private System.Windows.Forms.Button btnGetAllBySEx;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnIncr;
        private System.Windows.Forms.Label lblCounter;
        private System.Windows.Forms.Button btnDecrement;
        private System.Windows.Forms.TabPage tabMember;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemoveMember;
    }
}

