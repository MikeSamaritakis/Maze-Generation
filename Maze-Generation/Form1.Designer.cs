using Maze_Generation;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Maze_Generation
{


    public partial class Form1 : Form
    {
        private List<Cell> cells = new List<Cell>();
        private int cols, rows;
        private int cellSize = 20; // Change as needed
        private Cell currentCell;
        Graphics g;

        public Form1()
        {
            InitializeComponent();
            InitializeMaze();
        }

        private void InitializeMaze()
        {
            cols = mazePanel.Width / cellSize;
            rows = mazePanel.Height / cellSize;

            for (int j = 0; j < rows; j++)
            {
                for (int i = 0; i < cols; i++)
                {
                    cells.Add(new Cell(j, i));
                }
            }

            currentCell = cells[0];
            currentCell.Visited = true;

            // Set up Panel
            mazePanel.Paint += new PaintEventHandler(Draw);
            mazePanel.Invalidate(); // Causes the panel to redraw
        }

        private void Draw(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.Clear(Color.White);

            // Draw maze here
            foreach (var cell in cells)
            {
                DrawCell(cell, g);
            }
        }

        private void DrawCell(Cell cell, Graphics g)
        {
            int x = cell.Col * cellSize;
            int y = cell.Row * cellSize;
            Pen pen = new Pen(Color.Black, 2);

            // Top
            if (cell.Walls[0]) g.DrawLine(pen, x, y, x + cellSize, y);
            // Right
            if (cell.Walls[1]) g.DrawLine(pen, x + cellSize, y, x + cellSize, y + cellSize);
            // Bottom
            if (cell.Walls[2]) g.DrawLine(pen, x, y + cellSize, x + cellSize, y + cellSize);
            // Left
            if (cell.Walls[3]) g.DrawLine(pen, x, y, x, y + cellSize);
        }

        // Implement maze generation logic here (similar to Python version)
        // You might need to adapt it for C# and Windows Forms specifics
    }


    partial class Form1
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
            this.mazePanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // mazePanel
            // 
            this.mazePanel.Location = new System.Drawing.Point(0, -1);
            this.mazePanel.Name = "mazePanel";
            this.mazePanel.Size = new System.Drawing.Size(800, 451);
            this.mazePanel.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mazePanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mazePanel;
    }
}

