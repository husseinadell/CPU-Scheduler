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
        public static List<Process> processes = new List<Process>();
        int count = 0;
        public Form1()
        {
            InitializeComponent();
            fcfsB.Checked = false;
            count++;
            string pro = "P" + count.ToString();
            processT.AppendText(pro);
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
            count++;
            string pro = "P" + count.ToString();
            processT.Text = pro;
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

        private void restB_Click(object sender, EventArgs e)
        {
            processes.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        }

        private void startB_Click(object sender, EventArgs e)
        {
            if(!processes.Any())
            {
                MessageBox.Show("Please Enter Processes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (fcfsB.Checked) 
            {//fcfs
                
            }
            else if (sjfB.Checked)
            {
                if (preB.Checked)
                {//sjfPree
                    List<Process> sortedList = processes.OrderBy(a => a.getArrival()).ToList();

                }
                else if (nonpreB.Checked)
                {//sjfnonpre

                }
            }
            else if (priorityB.Checked)
            {
                if (preB.Checked)
                {//priorityPree

                }
                else if (nonpreB.Checked)
                {//prioritynonpre

                }
            }
            else if (rrB.Checked)
            {//rr
                if (string.IsNullOrEmpty(quantumT.Text))
                {
                    MessageBox.Show("Please Enter quantum!", "No Quantum", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                int Q = Convert.ToInt32(quantumT.Text);
            }
            else
            {//no chosen schedule is selected
                MessageBox.Show("Please Enter Process Technique", "process not chosen", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
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