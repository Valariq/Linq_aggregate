partial class FormMain
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.DataGridView dgvResults;
    private System.Windows.Forms.Label lblCount;
    private System.Windows.Forms.Label lblSum;
    private System.Windows.Forms.Label lblAvg;
    private System.Windows.Forms.Label lblMinMax;
    private System.Windows.Forms.Label lblAggregate;
    private System.Windows.Forms.Button btnCalcAggregates;
    private System.Windows.Forms.Button btnExceptOnlineOnly;
    private System.Windows.Forms.Button btnIntersectBoth;
    private System.Windows.Forms.Button btnUnionAllUnique;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        dgvResults = new DataGridView();
        lblCount = new Label();
        lblSum = new Label();
        lblAvg = new Label();
        lblMinMax = new Label();
        lblAggregate = new Label();
        btnCalcAggregates = new Button();
        btnExceptOnlineOnly = new Button();
        btnIntersectBoth = new Button();
        btnUnionAllUnique = new Button();
        ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
        SuspendLayout();
      
        dgvResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvResults.Location = new Point(20, 176);
        dgvResults.Name = "dgvResults";
        dgvResults.Size = new Size(760, 250);
        dgvResults.TabIndex = 0;
     
        lblCount.Location = new Point(20, 20);
        lblCount.Name = "lblCount";
        lblCount.Size = new Size(200, 20);
        lblCount.TabIndex = 1;
      
        lblSum.Location = new Point(240, 20);
        lblSum.Name = "lblSum";
        lblSum.Size = new Size(200, 20);
        lblSum.TabIndex = 2;
        
        lblAvg.Location = new Point(460, 20);
        lblAvg.Name = "lblAvg";
        lblAvg.Size = new Size(200, 20);
        lblAvg.TabIndex = 3;
      
        lblMinMax.Location = new Point(20, 60);
        lblMinMax.Name = "lblMinMax";
        lblMinMax.Size = new Size(300, 20);
        lblMinMax.TabIndex = 4;
     
        lblAggregate.Location = new Point(20, 100);
        lblAggregate.Name = "lblAggregate";
        lblAggregate.Size = new Size(500, 20);
        lblAggregate.TabIndex = 5;
     
        btnCalcAggregates.Location = new Point(620, 20);
        btnCalcAggregates.Name = "btnCalcAggregates";
        btnCalcAggregates.Size = new Size(160, 30);
        btnCalcAggregates.TabIndex = 6;
        btnCalcAggregates.Text = "Calc Aggregates";
        btnCalcAggregates.Click += btnCalcAggregates_Click;
     
        btnExceptOnlineOnly.Location = new Point(620, 60);
        btnExceptOnlineOnly.Name = "btnExceptOnlineOnly";
        btnExceptOnlineOnly.Size = new Size(160, 30);
        btnExceptOnlineOnly.TabIndex = 7;
        btnExceptOnlineOnly.Text = "Online Only";
        btnExceptOnlineOnly.Click += btnExceptOnlineOnly_Click;

        btnIntersectBoth.Location = new Point(620, 100);
        btnIntersectBoth.Name = "btnIntersectBoth";
        btnIntersectBoth.Size = new Size(160, 30);
        btnIntersectBoth.TabIndex = 8;
        btnIntersectBoth.Text = "Intersect";
        btnIntersectBoth.Click += btnIntersectBoth_Click;
   
        btnUnionAllUnique.Location = new Point(620, 140);
        btnUnionAllUnique.Name = "btnUnionAllUnique";
        btnUnionAllUnique.Size = new Size(160, 30);
        btnUnionAllUnique.TabIndex = 9;
        btnUnionAllUnique.Text = "Union";
        btnUnionAllUnique.Click += btnUnionAllUnique_Click;


        ClientSize = new Size(820, 430);
        Controls.Add(dgvResults);
        Controls.Add(lblCount);
        Controls.Add(lblSum);
        Controls.Add(lblAvg);
        Controls.Add(lblMinMax);
        Controls.Add(lblAggregate);
        Controls.Add(btnCalcAggregates);
        Controls.Add(btnExceptOnlineOnly);
        Controls.Add(btnIntersectBoth);
        Controls.Add(btnUnionAllUnique);
        Name = "FormMain";
        Text = "SQLite + LINQ Demo";
        ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
        ResumeLayout(false);
    }
}