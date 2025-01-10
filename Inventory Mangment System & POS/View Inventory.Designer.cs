namespace Inventory_Mangment_System___POS
{
    partial class View_Inventory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View_Inventory));
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            this.button1 = new System.Windows.Forms.Button();
            this.dgv_products = new System.Windows.Forms.DataGridView();
            this.btn_search = new Bunifu.UI.WinForms.BunifuTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_products)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(83)))), ((int)(((byte)(255)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(83)))), ((int)(((byte)(255)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Location = new System.Drawing.Point(991, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 39);
            this.button1.TabIndex = 26;
            this.button1.Text = "➕ ADD BRAND";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgv_products
            // 
            this.dgv_products.AllowUserToResizeRows = false;
            this.dgv_products.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_products.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.dgv_products.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_products.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_products.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(141)))), ((int)(((byte)(181)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_products.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_products.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(83)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_products.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_products.EnableHeadersVisualStyles = false;
            this.dgv_products.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(75)))), ((int)(((byte)(111)))));
            this.dgv_products.Location = new System.Drawing.Point(12, 53);
            this.dgv_products.Name = "dgv_products";
            this.dgv_products.RowHeadersVisible = false;
            this.dgv_products.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_products.Size = new System.Drawing.Size(1134, 576);
            this.dgv_products.TabIndex = 28;
            this.dgv_products.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_products_CellContentClick);
            // 
            // btn_search
            // 
            this.btn_search.AcceptsReturn = false;
            this.btn_search.AcceptsTab = false;
            this.btn_search.AnimationSpeed = 200;
            this.btn_search.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.btn_search.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.btn_search.AutoSizeHeight = true;
            this.btn_search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.btn_search.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_search.BackgroundImage")));
            this.btn_search.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.btn_search.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btn_search.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btn_search.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(83)))), ((int)(((byte)(255)))));
            this.btn_search.BorderRadius = 1;
            this.btn_search.BorderThickness = 1;
            this.btn_search.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.btn_search.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.btn_search.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
            this.btn_search.DefaultText = "";
            this.btn_search.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.btn_search.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_search.HideSelection = true;
            this.btn_search.IconLeft = null;
            this.btn_search.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.btn_search.IconPadding = 10;
            this.btn_search.IconRight = null;
            this.btn_search.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.btn_search.Lines = new string[0];
            this.btn_search.Location = new System.Drawing.Point(12, 6);
            this.btn_search.MaxLength = 32767;
            this.btn_search.MinimumSize = new System.Drawing.Size(1, 1);
            this.btn_search.Modified = false;
            this.btn_search.Multiline = false;
            this.btn_search.Name = "btn_search";
            stateProperties5.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties5.FillColor = System.Drawing.Color.Empty;
            stateProperties5.ForeColor = System.Drawing.Color.Empty;
            stateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.btn_search.OnActiveState = stateProperties5;
            stateProperties6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties6.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.btn_search.OnDisabledState = stateProperties6;
            stateProperties7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties7.FillColor = System.Drawing.Color.Empty;
            stateProperties7.ForeColor = System.Drawing.Color.Empty;
            stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.btn_search.OnHoverState = stateProperties7;
            stateProperties8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(83)))), ((int)(((byte)(255)))));
            stateProperties8.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            stateProperties8.ForeColor = System.Drawing.Color.WhiteSmoke;
            stateProperties8.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.btn_search.OnIdleState = stateProperties8;
            this.btn_search.Padding = new System.Windows.Forms.Padding(3);
            this.btn_search.PasswordChar = '\0';
            this.btn_search.PlaceholderForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_search.PlaceholderText = "Search For Products";
            this.btn_search.ReadOnly = false;
            this.btn_search.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.btn_search.SelectedText = "";
            this.btn_search.SelectionLength = 0;
            this.btn_search.SelectionStart = 0;
            this.btn_search.ShortcutsEnabled = true;
            this.btn_search.Size = new System.Drawing.Size(260, 39);
            this.btn_search.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.btn_search.TabIndex = 29;
            this.btn_search.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_search.TextMarginBottom = 0;
            this.btn_search.TextMarginLeft = 3;
            this.btn_search.TextMarginTop = 1;
            this.btn_search.TextPlaceholder = "Search For Products";
            this.btn_search.UseSystemPasswordChar = false;
            this.btn_search.WordWrap = true;
            this.btn_search.TextChanged += new System.EventHandler(this.btn_search_TextChanged);
            // 
            // View_Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(63)))));
            this.ClientSize = new System.Drawing.Size(1158, 641);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.dgv_products);
            this.Controls.Add(this.button1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(63)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "View_Inventory";
            this.Text = "View_Inventory";
            this.Load += new System.EventHandler(this.View_Inventory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_products)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgv_products;
        private Bunifu.UI.WinForms.BunifuTextBox btn_search;
    }
}