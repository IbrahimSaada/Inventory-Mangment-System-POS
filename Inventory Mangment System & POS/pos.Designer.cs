namespace Inventory_Mangment_System___POS
{
    partial class pos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pos));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_balance = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbl_invoice = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_discounted = new System.Windows.Forms.Label();
            this.lbl_discRate = new System.Windows.Forms.Label();
            this.lbl_totqty = new System.Windows.Forms.Label();
            this.lbl_original = new System.Windows.Forms.Label();
            this.lbltotqty = new System.Windows.Forms.Label();
            this.lbldiscRate = new System.Windows.Forms.Label();
            this.lbldiscounted = new System.Windows.Forms.Label();
            this.lbloriginal = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_barcode = new System.Windows.Forms.TextBox();
            this.txt_description = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_price = new System.Windows.Forms.TextBox();
            this.txt_qty = new System.Windows.Forms.TextBox();
            this.txt_disc = new System.Windows.Forms.TextBox();
            this.txt_total = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dgvbill = new System.Windows.Forms.DataGridView();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.txt_customerName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_customer = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_contactinfo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_address = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(63)))));
            this.panel1.Controls.Add(this.lbl_balance);
            this.panel1.Controls.Add(this.lbl_name);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.lbl_invoice);
            this.panel1.Location = new System.Drawing.Point(8, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1147, 59);
            this.panel1.TabIndex = 0;
            // 
            // lbl_balance
            // 
            this.lbl_balance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_balance.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_balance.ForeColor = System.Drawing.Color.White;
            this.lbl_balance.Location = new System.Drawing.Point(1058, 1);
            this.lbl_balance.Name = "lbl_balance";
            this.lbl_balance.Size = new System.Drawing.Size(79, 56);
            this.lbl_balance.TabIndex = 1;
            this.lbl_balance.Text = "0.00";
            this.lbl_balance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_balance.Click += new System.EventHandler(this.lbl_balance_Click);
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.ForeColor = System.Drawing.Color.White;
            this.lbl_name.Location = new System.Drawing.Point(8, 32);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(73, 13);
            this.lbl_name.TabIndex = 1;
            this.lbl_name.Text = "Cashier Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "POINT OF SALE";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label12.Location = new System.Drawing.Point(448, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(129, 21);
            this.label12.TabIndex = 0;
            this.label12.Text = "Transaction No:";
            // 
            // lbl_invoice
            // 
            this.lbl_invoice.AutoSize = true;
            this.lbl_invoice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_invoice.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_invoice.Location = new System.Drawing.Point(573, 21);
            this.lbl_invoice.Name = "lbl_invoice";
            this.lbl_invoice.Size = new System.Drawing.Size(91, 21);
            this.lbl_invoice.TabIndex = 11;
            this.lbl_invoice.Text = "000000000";
            this.lbl_invoice.Click += new System.EventHandler(this.label14_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.panel2.Controls.Add(this.lbl_discounted);
            this.panel2.Controls.Add(this.lbl_discRate);
            this.panel2.Controls.Add(this.lbl_totqty);
            this.panel2.Controls.Add(this.lbl_original);
            this.panel2.Controls.Add(this.lbltotqty);
            this.panel2.Controls.Add(this.lbldiscRate);
            this.panel2.Controls.Add(this.lbldiscounted);
            this.panel2.Controls.Add(this.lbloriginal);
            this.panel2.Location = new System.Drawing.Point(912, 356);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(237, 177);
            this.panel2.TabIndex = 5;
            // 
            // lbl_discounted
            // 
            this.lbl_discounted.AutoSize = true;
            this.lbl_discounted.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_discounted.ForeColor = System.Drawing.Color.White;
            this.lbl_discounted.Location = new System.Drawing.Point(179, 63);
            this.lbl_discounted.Name = "lbl_discounted";
            this.lbl_discounted.Size = new System.Drawing.Size(40, 20);
            this.lbl_discounted.TabIndex = 14;
            this.lbl_discounted.Text = "0.00";
            // 
            // lbl_discRate
            // 
            this.lbl_discRate.AutoSize = true;
            this.lbl_discRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_discRate.ForeColor = System.Drawing.Color.White;
            this.lbl_discRate.Location = new System.Drawing.Point(179, 89);
            this.lbl_discRate.Name = "lbl_discRate";
            this.lbl_discRate.Size = new System.Drawing.Size(40, 20);
            this.lbl_discRate.TabIndex = 13;
            this.lbl_discRate.Text = "0.00";
            // 
            // lbl_totqty
            // 
            this.lbl_totqty.AutoSize = true;
            this.lbl_totqty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_totqty.ForeColor = System.Drawing.Color.White;
            this.lbl_totqty.Location = new System.Drawing.Point(179, 115);
            this.lbl_totqty.Name = "lbl_totqty";
            this.lbl_totqty.Size = new System.Drawing.Size(40, 20);
            this.lbl_totqty.TabIndex = 12;
            this.lbl_totqty.Text = "0.00";
            // 
            // lbl_original
            // 
            this.lbl_original.AutoSize = true;
            this.lbl_original.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_original.ForeColor = System.Drawing.Color.White;
            this.lbl_original.Location = new System.Drawing.Point(179, 37);
            this.lbl_original.Name = "lbl_original";
            this.lbl_original.Size = new System.Drawing.Size(40, 20);
            this.lbl_original.TabIndex = 11;
            this.lbl_original.Text = "0.00";
            // 
            // lbltotqty
            // 
            this.lbltotqty.AutoSize = true;
            this.lbltotqty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotqty.ForeColor = System.Drawing.Color.White;
            this.lbltotqty.Location = new System.Drawing.Point(12, 115);
            this.lbltotqty.Name = "lbltotqty";
            this.lbltotqty.Size = new System.Drawing.Size(107, 20);
            this.lbltotqty.TabIndex = 10;
            this.lbltotqty.Text = "Total Quantity";
            // 
            // lbldiscRate
            // 
            this.lbldiscRate.AutoSize = true;
            this.lbldiscRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldiscRate.ForeColor = System.Drawing.Color.White;
            this.lbldiscRate.Location = new System.Drawing.Point(8, 89);
            this.lbldiscRate.Name = "lbldiscRate";
            this.lbldiscRate.Size = new System.Drawing.Size(115, 20);
            this.lbldiscRate.TabIndex = 9;
            this.lbldiscRate.Text = " Discount Rate";
            // 
            // lbldiscounted
            // 
            this.lbldiscounted.AutoSize = true;
            this.lbldiscounted.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldiscounted.ForeColor = System.Drawing.Color.White;
            this.lbldiscounted.Location = new System.Drawing.Point(12, 63);
            this.lbldiscounted.Name = "lbldiscounted";
            this.lbldiscounted.Size = new System.Drawing.Size(129, 20);
            this.lbldiscounted.TabIndex = 8;
            this.lbldiscounted.Text = "Discounted Price";
            // 
            // lbloriginal
            // 
            this.lbloriginal.AutoSize = true;
            this.lbloriginal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbloriginal.ForeColor = System.Drawing.Color.White;
            this.lbloriginal.Location = new System.Drawing.Point(12, 37);
            this.lbloriginal.Name = "lbloriginal";
            this.lbloriginal.Size = new System.Drawing.Size(101, 20);
            this.lbloriginal.TabIndex = 7;
            this.lbloriginal.Text = "Original Price";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.pictureBox3);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Location = new System.Drawing.Point(912, 538);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(237, 96);
            this.panel3.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(34, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Calendar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(34, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Time";
            // 
            // txt_barcode
            // 
            this.txt_barcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_barcode.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_barcode.Location = new System.Drawing.Point(8, 133);
            this.txt_barcode.Name = "txt_barcode";
            this.txt_barcode.Size = new System.Drawing.Size(128, 22);
            this.txt_barcode.TabIndex = 0;
            this.txt_barcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_barcode.TextChanged += new System.EventHandler(this.txt_barcode_TextChanged);
            this.txt_barcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_barcode_KeyPress);
            // 
            // txt_description
            // 
            this.txt_description.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_description.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txt_description.Location = new System.Drawing.Point(135, 133);
            this.txt_description.Name = "txt_description";
            this.txt_description.Size = new System.Drawing.Size(168, 22);
            this.txt_description.TabIndex = 13;
            this.txt_description.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label13.Location = new System.Drawing.Point(54, 113);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 17);
            this.label13.TabIndex = 10;
            this.label13.Text = "Barcode";
            // 
            // txt_price
            // 
            this.txt_price.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_price.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txt_price.Location = new System.Drawing.Point(302, 133);
            this.txt_price.Name = "txt_price";
            this.txt_price.Size = new System.Drawing.Size(145, 22);
            this.txt_price.TabIndex = 14;
            this.txt_price.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_qty
            // 
            this.txt_qty.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_qty.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txt_qty.Location = new System.Drawing.Point(446, 133);
            this.txt_qty.Name = "txt_qty";
            this.txt_qty.Size = new System.Drawing.Size(139, 22);
            this.txt_qty.TabIndex = 15;
            this.txt_qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_disc
            // 
            this.txt_disc.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_disc.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txt_disc.Location = new System.Drawing.Point(584, 133);
            this.txt_disc.Name = "txt_disc";
            this.txt_disc.Size = new System.Drawing.Size(154, 22);
            this.txt_disc.TabIndex = 16;
            this.txt_disc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_total
            // 
            this.txt_total.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_total.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txt_total.Location = new System.Drawing.Point(737, 133);
            this.txt_total.Name = "txt_total";
            this.txt_total.Size = new System.Drawing.Size(170, 22);
            this.txt_total.TabIndex = 17;
            this.txt_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label15.Location = new System.Drawing.Point(152, 114);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(119, 16);
            this.label15.TabIndex = 18;
            this.label15.Text = "Item Description";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label16.Location = new System.Drawing.Point(337, 113);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(74, 16);
            this.label16.TabIndex = 19;
            this.label16.Text = "Unit Price";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label17.Location = new System.Drawing.Point(638, 114);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(51, 16);
            this.label17.TabIndex = 20;
            this.label17.Text = "%Disc";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label19.Location = new System.Drawing.Point(789, 114);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(43, 16);
            this.label19.TabIndex = 22;
            this.label19.Text = "Total";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label14.Location = new System.Drawing.Point(500, 113);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(28, 16);
            this.label14.TabIndex = 23;
            this.label14.Text = "qty";
            // 
            // dgvbill
            // 
            this.dgvbill.AllowUserToResizeRows = false;
            this.dgvbill.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvbill.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.dgvbill.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvbill.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvbill.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(141)))), ((int)(((byte)(181)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.MenuText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvbill.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvbill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(83)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvbill.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvbill.EnableHeadersVisualStyles = false;
            this.dgvbill.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(75)))), ((int)(((byte)(111)))));
            this.dgvbill.Location = new System.Drawing.Point(8, 159);
            this.dgvbill.Name = "dgvbill";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvbill.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvbill.RowHeadersVisible = false;
            this.dgvbill.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvbill.Size = new System.Drawing.Size(899, 475);
            this.dgvbill.TabIndex = 24;
            this.dgvbill.SelectionChanged += new System.EventHandler(this.dgvbill_SelectionChanged);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // txt_customerName
            // 
            this.txt_customerName.BackColor = System.Drawing.Color.White;
            this.txt_customerName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.txt_customerName.ForeColor = System.Drawing.Color.Black;
            this.txt_customerName.Location = new System.Drawing.Point(8, 88);
            this.txt_customerName.Multiline = true;
            this.txt_customerName.Name = "txt_customerName";
            this.txt_customerName.Size = new System.Drawing.Size(226, 21);
            this.txt_customerName.TabIndex = 31;
            this.txt_customerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_customerName.TextChanged += new System.EventHandler(this.txt_customerName_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(53, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 21);
            this.label4.TabIndex = 30;
            this.label4.Text = "Customer Name";
            // 
            // cmb_customer
            // 
            this.cmb_customer.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmb_customer.FormattingEnabled = true;
            this.cmb_customer.Location = new System.Drawing.Point(233, 88);
            this.cmb_customer.Name = "cmb_customer";
            this.cmb_customer.Size = new System.Drawing.Size(226, 21);
            this.cmb_customer.TabIndex = 32;
            this.cmb_customer.SelectedIndexChanged += new System.EventHandler(this.cmb_customer_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(277, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 21);
            this.label5.TabIndex = 33;
            this.label5.Text = "Find Customer";
            // 
            // txt_contactinfo
            // 
            this.txt_contactinfo.BackColor = System.Drawing.Color.White;
            this.txt_contactinfo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.txt_contactinfo.ForeColor = System.Drawing.Color.Black;
            this.txt_contactinfo.Location = new System.Drawing.Point(458, 88);
            this.txt_contactinfo.Multiline = true;
            this.txt_contactinfo.Name = "txt_contactinfo";
            this.txt_contactinfo.Size = new System.Drawing.Size(225, 21);
            this.txt_contactinfo.TabIndex = 34;
            this.txt_contactinfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Location = new System.Drawing.Point(483, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(165, 21);
            this.label6.TabIndex = 35;
            this.label6.Text = "Contact Information";
            // 
            // txt_address
            // 
            this.txt_address.BackColor = System.Drawing.Color.White;
            this.txt_address.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.txt_address.ForeColor = System.Drawing.Color.Black;
            this.txt_address.Location = new System.Drawing.Point(682, 88);
            this.txt_address.Multiline = true;
            this.txt_address.Name = "txt_address";
            this.txt_address.Size = new System.Drawing.Size(225, 21);
            this.txt_address.TabIndex = 36;
            this.txt_address.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Location = new System.Drawing.Point(762, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 21);
            this.label7.TabIndex = 37;
            this.label7.Text = "Address";
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Image = global::Inventory_Mangment_System___POS.Properties.Resources.icons8_payment_20__1_;
            this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.Location = new System.Drawing.Point(912, 155);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(115, 62);
            this.button7.TabIndex = 29;
            this.button7.Text = "  Settle    [F4]";
            this.button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::Inventory_Mangment_System___POS.Properties.Resources.icons8_print_20;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(1031, 155);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 62);
            this.button1.TabIndex = 28;
            this.button1.Text = "  Print    [F5]";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Image = global::Inventory_Mangment_System___POS.Properties.Resources.icons8_remove_20;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(992, 88);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(76, 62);
            this.button5.TabIndex = 26;
            this.button5.Text = "Remove [F2]";
            this.button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Image = global::Inventory_Mangment_System___POS.Properties.Resources.icons8_edit_20;
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(1072, 88);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(76, 62);
            this.button6.TabIndex = 27;
            this.button6.Text = "Edit    [F3]";
            this.button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Image = global::Inventory_Mangment_System___POS.Properties.Resources.icons8_clear_20;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(912, 289);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(237, 62);
            this.button3.TabIndex = 4;
            this.button3.Text = "         [F7]     Clear Invoice";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Inventory_Mangment_System___POS.Properties.Resources.icons8_schedule_20__1_1;
            this.pictureBox3.Location = new System.Drawing.Point(3, 59);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(25, 25);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Inventory_Mangment_System___POS.Properties.Resources.icons8_time_201;
            this.pictureBox2.Location = new System.Drawing.Point(3, 19);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 25);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = global::Inventory_Mangment_System___POS.Properties.Resources.icons8_discount_20__1_;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(912, 222);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(237, 62);
            this.button2.TabIndex = 2;
            this.button2.Text = "         [F6]     Add Discount";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_add
            // 
            this.btn_add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.btn_add.FlatAppearance.BorderSize = 0;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.ForeColor = System.Drawing.Color.White;
            this.btn_add.Image = global::Inventory_Mangment_System___POS.Properties.Resources.icons8_add_20;
            this.btn_add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_add.Location = new System.Drawing.Point(912, 88);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(76, 62);
            this.btn_add.TabIndex = 1;
            this.btn_add.Text = "              Add    [F1]";
            this.btn_add.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_add.UseVisualStyleBackColor = false;
            this.btn_add.Click += new System.EventHandler(this.button1_Click);
            // 
            // pos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(63)))));
            this.ClientSize = new System.Drawing.Size(1158, 641);
            this.ControlBox = false;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_address);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_contactinfo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmb_customer);
            this.Controls.Add(this.txt_customerName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.dgvbill);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txt_price);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txt_total);
            this.Controls.Add(this.txt_disc);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txt_qty);
            this.Controls.Add(this.txt_description);
            this.Controls.Add(this.txt_barcode);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "pos";
            this.Text = "pos";
            this.Load += new System.EventHandler(this.pos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_balance;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbltotqty;
        private System.Windows.Forms.Label lbldiscRate;
        private System.Windows.Forms.Label lbldiscounted;
        private System.Windows.Forms.Label lbloriginal;
        private System.Windows.Forms.Label lbl_discounted;
        private System.Windows.Forms.Label lbl_discRate;
        private System.Windows.Forms.Label lbl_totqty;
        private System.Windows.Forms.Label lbl_original;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_barcode;
        private System.Windows.Forms.Label lbl_invoice;
        private System.Windows.Forms.TextBox txt_description;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_price;
        private System.Windows.Forms.TextBox txt_qty;
        private System.Windows.Forms.TextBox txt_disc;
        private System.Windows.Forms.TextBox txt_total;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView dgvbill;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox txt_customerName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_customer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_contactinfo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_address;
        private System.Windows.Forms.Label label7;
    }
}