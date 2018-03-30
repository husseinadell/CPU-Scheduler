using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduler
{
    public partial class Form1 : Form
    {
        int count;
        public static List<Process> processes = new List<Process>();

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fcfsB_CheckedChanged(object sender, EventArgs e)
        {
            priorityT.Enabled = false;
            panel1.Visible = false;
            panel2.Visible = false;
        }

        private void sjfB_CheckedChanged(object sender, EventArgs e)
        {
            priorityT.Enabled = false;
            panel1.Visible = true;
            panel2.Visible = false;
        }

        private void priorityB_CheckedChanged(object sender, EventArgs e)
        {
            priorityT.Enabled = true;
            panel1.Visible = true;
            panel2.Visible = false;
        }

        private void rrB_CheckedChanged(object sender, EventArgs e)
        {
            priorityT.Enabled = false;
            panel1.Visible = false;
            panel2.Visible = true;
        }

        private void addB_Click(object sender, EventArgs e)
        {
            DataTable ss = new DataTable();
            ss.Columns.Add("Process");
            ss.Columns.Add("Arrival");
            ss.Columns.Add("Burst");
            ss.Columns.Add("Priority");

            DataRow row = ss.NewRow();
            row["Process"] = processT.Text;
            row["Arrival"] = arrivalT.Text;
            row["Burst"] = burstT.Text;
            row["Priority"] = priorityT.Text;
            if(priorityT.Enabled == false)
            {
                Process p = new Process(processT.Text, Convert.ToInt32(arrivalT.Text), Convert.ToInt32(burstT.Text));
                processes.Add(p);
            }
            else 
            {
                Process p = new Process(processT.Text, Convert.ToInt32(arrivalT.Text), Convert.ToInt32(burstT.Text), Convert.ToInt32(priorityT.Text));
                processes.Add(p);
            }
            ss.Rows.Add(row);

            foreach (DataRow Drow in ss.Rows)
            {
                int num = dataGridView1.Rows.Add();
                dataGridView1.Rows[num].Cells[0].Value = Drow["Process"].ToString();
                dataGridView1.Rows[num].Cells[1].Value = Drow["Arrival"].ToString();
                dataGridView1.Rows[num].Cells[2].Value = Drow["Burst"].ToString();
                dataGridView1.Rows[num].Cells[3].Value = Drow["Priority"].ToString();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
public class Process
{
    private string name;
    private int arrival, burst, priority, departure, waiting;
    public Process(string n, int a, int b)
    {
        name = n;
        arrival = a;
        burst = b;
        priority = 0;
    }
    public Process(string n, int a, int b, int p)
    {
        name = n;
        arrival = a;
        burst = b;
        priority = p;
    }
    public void setDeparture(int d)
    {
        departure = d;
    }
    public string getName()
    {
        return name;
    }
    public int getArrival()
    {
        return arrival;
    }
    public int getBurst()
    {
        return burst;
    }
    public int getPriority()
    {
        return priority;
    }
    public int getDeparture()
    {
        return departure;
    }
    public double getWaitingTime()
    {
        waiting = departure - arrival - burst;
        return waiting;
    }
};