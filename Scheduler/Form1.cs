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
        int count = 1;
        public Form1()
        {
            InitializeComponent();
            fcfsB.Checked = false;
            processT.Text = "P1";
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
            count++;
            string pro = "P" + count.ToString();
            processT.Text = pro;
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
            while (chart1.Series.Count > 0)
            { chart1.Series.RemoveAt(0); }
            processes.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            count = 1;
            string pro = "P" + count.ToString();
            processT.Text = pro;
            waitingT.Text = "";
        }

        private void startB_Click(object sender, EventArgs e)
        {
            while (chart1.Series.Count > 0)
            { chart1.Series.RemoveAt(0); }
            if(!processes.Any())
            {
                MessageBox.Show("Please Enter Processes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (fcfsB.Checked) 
            {//fcfs
                fillchartfcfs();    
            }
            else if (sjfB.Checked)
            {
                if (preB.Checked)
                {//sjfPree
                    fillchartpresjf();
                }
                else if (nonpreB.Checked)
                {//sjfnonpre
                    fillchartnonpresjf();
                }
                else
                {
                    MessageBox.Show("Please Enter Processes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (priorityB.Checked)
            {
                if (preB.Checked)
                {//priorityPree
                    fillchartpreprio();
                }
                else if (nonpreB.Checked)
                {//prioritynonpre
                    fillchartnonprepriority();
                }
                else
                {
                    MessageBox.Show("Please Enter Processes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (rrB.Checked)
            {//rr
                if (string.IsNullOrEmpty(quantumT.Text))
                {
                    MessageBox.Show("Please Enter quantum!", "No Quantum", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                int Q = Convert.ToInt32(quantumT.Text);
                fillchartRR(Q);
            }
            else
            {//no chosen schedule is selected
                MessageBox.Show("Please Enter Process Technique", "process not chosen", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void fillchartRR(int Q) 
        {

            int totalBurst = 0;
            List<Process> sortedList = processes.OrderBy(a => a.getArrival()).ToList();
            for (int i = 0; i < sortedList.Count; i++)
            {
                totalBurst += sortedList[i].getBurst();
            }
            Random r = new Random();
            for (int i = 0; i < processes.Count; i++)
            {
                chart1.Series.Add(processes[i].getName());
                chart1.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.RangeBar;
                chart1.Series[i].Color = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
            }
            int currentlyExecuted = 0;
            int time = sortedList[0].getArrival();
            int totalJobs = processes.Count;
            int waitingTimeround = 0;
            int currentJob = 0;
            List<Process> final =new List<Process>();
            while (currentlyExecuted < totalBurst)
            {
                Process current = sortedList.ElementAt(currentJob);
                if (current.getArrival() <= time)
                {
                    if ((current.getBurst() - current.getExec()) > 0)
                    {
                        if ((current.getBurst() - current.getExec()) >= Q)
                        {
                            current.setExec(current.getExec() + Q);
                            chart1.Series[current.getName()].Points.AddXY(current.getName(),time + Q,time);
                            waitingTimeround = waitingTimeround + (time - current.getDeparture());
                            time = time + Q;
                            currentlyExecuted += Q;
                            current.setDeparture(time);
                        }
                        else
                        {
                            
                            chart1.Series[current.getName()].Points.AddXY(current.getName(), time + current.getBurst()-current.getExec(), time);
                            
                            waitingTimeround = waitingTimeround + (time - current.getDeparture());
                            time = time + (current.getBurst()-current.getExec());
                            currentlyExecuted += (current.getBurst() - current.getExec());
                            current.setExec(current.getBurst());
                            current.setDeparture(time);
                        }
                    }
                } currentJob = (++currentJob) % totalJobs;
            }
            waitingT.Text = (waitingTimeround / totalJobs).ToString();
        }
        private void fillchartpreprio()
        {
            List<Process> sortedList = processes.OrderBy(a => a.getPriority()).ToList();
            int totalBurst = 0;
            for (int i = 0; i < sortedList.Count; i++)
            {
                totalBurst += sortedList[i].getBurst();
            }
            int var = processes.Count;
            int waitingTime = 0;
            Process old = sortedList[0];
            foreach (var item in sortedList)
            {
                if (item.getArrival() < old.getArrival())
                { old = item; }
            }
            int initialTime = old.getArrival();
            Random r = new Random();
            for (int i = 0; i < processes.Count; i++)
            {
                chart1.Series.Add(processes[i].getName());
                chart1.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.RangeBar;
                //chart1.Series[i].Color = Color.FromArgb(i * 10, i * 20, i *30);
                chart1.Series[i].Color = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
                //chart1.Series[i].Color = Color.Yellow;
                //chart1.Series[i].MarkerColor = Color.White;
            }
            for (int time = initialTime; time < (totalBurst + initialTime); time++)
            {
                //sortedList = sortedList.OrderBy(b => (b.getBurst() - b.getExec())).ToList();
                for (int j = 0; j < var; j++)
                {
                    if (sortedList[j].getArrival() <= time)
                    {
                        if (old != sortedList[j])
                        {
                            waitingTime = waitingTime + (time - sortedList[j].getDeparture());
                            old.setDeparture(time);
                            old = sortedList[j];
                        }
                        chart1.Series[sortedList[j].getName()].Points.AddXY(sortedList[j].getName(), time + 1, time);
                        sortedList[j].setExec((sortedList[j].getExec()) + 1);
                        if (sortedList[j].getBurst() == sortedList[j].getExec())
                        {
                            sortedList.RemoveAt(j);
                            var--;
                        }
                        break;
                    }
                }
            }
            waitingT.Text = ((double)waitingTime / processes.Count).ToString();
        }
        private void fillchartnonprepriority()
        {
            List<Process> sortedList = processes.OrderBy(a => a.getPriority()).ToList();
            List<Process> sjfSorted = new List<Process>();
            int totalBurst = 0;
            for (int i = 0; i < sortedList.Count; i++)
            {
                totalBurst += sortedList[i].getBurst();
            }
            int countt = sortedList.Count;
            for (int i = 0; i <= totalBurst; i++)
            {
                for (int j = 0; j < countt; j++)
                {
                    if (sortedList[j].getArrival() <= i)
                    {
                        sjfSorted.Add(sortedList[j]);
                        i = i + sortedList[j].getBurst() - 1;
                        sortedList.RemoveAt(j);
                        countt--;
                        break;
                    }
                }
            }
            int waiting = 0;
            Random r = new Random();
            for (int i = 0; i < processes.Count; i++)
            {
                chart1.Series.Add(processes[i].getName());
                chart1.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.RangeBar;
                //chart1.Series[i].Color = Color.FromArgb(i * 10, i * 20, i *30);
                chart1.Series[i].Color = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
                //chart1.Series[i].Color = Color.Yellow;
                //chart1.Series[i].MarkerColor = Color.White;
            }
            for (int i = 0; i < sjfSorted.Count; i++)
            {
                if (i == 0)
                {
                    chart1.Series[sjfSorted[i].getName()].Points.AddXY(sjfSorted[i].getName(), sjfSorted[i].getArrival() + sjfSorted[i].getBurst(), sjfSorted[i].getArrival());
                    waiting += sjfSorted[i].getArrival() + sjfSorted[i].getBurst();
                    sjfSorted[i].setDeparture(waiting);
                }
                else
                {
                    if (waiting > sjfSorted[i].getArrival())
                    {
                        chart1.Series[sjfSorted[i].getName()].Points.AddXY(sjfSorted[i].getName(), waiting + sjfSorted[i].getBurst(), waiting);
                        waiting += sjfSorted[i].getBurst();
                        sjfSorted[i].setDeparture(waiting);
                    }
                    else
                    {
                        chart1.Series[sjfSorted[i].getName()].Points.AddXY(sjfSorted[i].getName(), sjfSorted[i].getArrival() + sjfSorted[i].getBurst(), sjfSorted[i].getArrival());
                        waiting = sjfSorted[i].getBurst() + sjfSorted[i].getArrival();
                        sjfSorted[i].setDeparture(waiting);
                    }
                }
            }
            double timeWait = 0;
            for (int i = 0; i < sjfSorted.Count; i++)
            {
                timeWait += sjfSorted[i].getWaitingTime();
            }
            waitingT.Text = (timeWait / sjfSorted.Count).ToString();
        }
        private void fillchartpresjf()
        {
            List<Process> sortedList = processes.OrderBy(a => a.getBurst()).ToList();
            int totalBurst = 0;
            for (int i = 0; i < sortedList.Count; i++)
            {
                totalBurst += sortedList[i].getBurst();
            }
            int var = processes.Count;
            int waitingTime = 0;
            Process old = sortedList[0];
            foreach (var item in sortedList)
            {
                if(item.getArrival() < old.getArrival())
                { old = item; }
            }
            int initialTime = old.getArrival();
            Random r = new Random();
            for (int i = 0; i < processes.Count; i++)
            {
                chart1.Series.Add(processes[i].getName());
                chart1.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.RangeBar;
                //chart1.Series[i].Color = Color.FromArgb(i * 10, i * 20, i *30);
                chart1.Series[i].Color = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
                //chart1.Series[i].Color = Color.Yellow;
                //chart1.Series[i].MarkerColor = Color.White;
            }
            for (int time=initialTime;time<(totalBurst + initialTime);time++)
            {
                sortedList = sortedList.OrderBy(b => (b.getBurst()-b.getExec())).ToList();
                for(int j= 0; j<var ; j++)
                {
                    if(sortedList[j].getArrival() <= time)
                    {
                        if (old != sortedList[j])
                        {
                            waitingTime = waitingTime + (time-sortedList[j].getDeparture());
                            old.setDeparture(time);
                            old = sortedList[j];
                        }
                        chart1.Series[sortedList[j].getName()].Points.AddXY(sortedList[j].getName(),time+1,time);
                        sortedList[j].setExec((sortedList[j].getExec())+1);
                        if(sortedList[j].getBurst() == sortedList[j].getExec())
                        {
                            sortedList.RemoveAt(j);
                            var -- ;
                        }
                        break;
                    }
                }
            }
            waitingT.Text = ((double)waitingTime / processes.Count).ToString();
        }
        private void fillchartnonpresjf()
        {
            List<Process> sortedList = processes.OrderBy(a => a.getBurst()).ToList();
            List<Process> sjfSorted = new List<Process>();
            int totalBurst = 0;
            for (int i = 0; i < sortedList.Count; i++)
            {
                totalBurst += sortedList[i].getBurst();
            }
            int countt = sortedList.Count;
            for (int i = 0; i <= totalBurst; i++)
            {
                for (int j = 0; j < countt; j++)
                {
                    if (sortedList[j].getArrival() <= i)
                    {
                        sjfSorted.Add(sortedList[j]);
                        i = i + sortedList[j].getBurst() - 1;
                        sortedList.RemoveAt(j);
                        countt--;
                        break;
                    }
                }
            }
            int waiting = 0;
            Random r = new Random();
            for (int i = 0; i < processes.Count; i++)
            {
                chart1.Series.Add(processes[i].getName());
                chart1.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.RangeBar;
                //chart1.Series[i].Color = Color.FromArgb(i * 10, i * 20, i *30);
                chart1.Series[i].Color = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
                //chart1.Series[i].Color = Color.Yellow;
                //chart1.Series[i].MarkerColor = Color.White;
            }
            for (int i = 0; i < sjfSorted.Count; i++)
            {
                if (i == 0)
                {
                    chart1.Series[sjfSorted[i].getName()].Points.AddXY(sjfSorted[i].getName(), sjfSorted[i].getArrival() + sjfSorted[i].getBurst(), sjfSorted[i].getArrival());
                    waiting += sjfSorted[i].getArrival() + sjfSorted[i].getBurst();
                    sjfSorted[i].setDeparture(waiting);
                }
                else
                {
                    if (waiting > sjfSorted[i].getArrival())
                    {
                        chart1.Series[sjfSorted[i].getName()].Points.AddXY(sjfSorted[i].getName(), waiting + sjfSorted[i].getBurst(), waiting);
                        waiting += sjfSorted[i].getBurst();
                        sjfSorted[i].setDeparture(waiting);
                    }
                    else
                    {
                        chart1.Series[sjfSorted[i].getName()].Points.AddXY(sjfSorted[i].getName(), sjfSorted[i].getArrival() + sjfSorted[i].getBurst(), sjfSorted[i].getArrival());
                        waiting = sjfSorted[i].getBurst() + sjfSorted[i].getArrival();
                        sjfSorted[i].setDeparture(waiting);
                    }
                }
            }
            double timeWait = 0;
            for (int i = 0; i < sjfSorted.Count; i++)
            {
                timeWait += sjfSorted[i].getWaitingTime();
            }
            waitingT.Text = (timeWait / sjfSorted.Count).ToString();
        }
        private void fillchartfcfs()
        {
            int waiting = 0;
            processes = processes.OrderBy(a => a.getArrival()).ToList();
            Random r = new Random();
            for (int i = 0; i < processes.Count; i++)
                {
                    chart1.Series.Add(processes[i].getName());
                    chart1.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.RangeBar;
                    chart1.Series[i].Color = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
                }
            for (int i = 0; i < processes.Count; i++)
            {
                int time = 0;
                if (i == 0)
                {
                    chart1.Series[processes[i].getName()].Points.AddXY(processes[i].getName(), processes[i].getBurst() + processes[i].getArrival(), processes[i].getArrival());
                    waiting += processes[i].getBurst() + processes[i].getArrival();
                    processes[i].setDeparture(waiting);
                }
                else
                {
                    if (waiting > processes[i].getArrival())
                    {
                        chart1.Series[processes[i].getName()].Points.AddXY(processes[i].getName(), waiting + processes[i].getBurst(), waiting);
                        waiting += processes[i].getBurst();
                        processes[i].setDeparture(waiting);
                    }
                    else
                    {
                        chart1.Series[processes[i].getName()].Points.AddXY(processes[i].getName(), processes[i].getBurst() + processes[i].getArrival(), processes[i].getArrival());
                        waiting = processes[i].getBurst() + processes[i].getArrival();
                        processes[i].setDeparture(waiting);
                    }
                }
            }
            double timeWait = 0;
            for (int i = 0; i < processes.Count; i++)
            {
                timeWait += processes[i].getWaitingTime();
            }
            waitingT.Text = (timeWait/processes.Count).ToString();
		}
        
        

        private void chart1_Click(object sender, EventArgs e)
        {

           // fillchart();

        }
    }
}
public class Process
{
    private string name;
    private int arrival, burst, priority, departure, waiting,exec;
    public Process(string n, int a, int b)
    {
        name = n;
        arrival = a;
        burst = b;
        priority = 0;
        exec = 0;
        departure = arrival;
    }
    public Process(string n, int a, int b, int p)
    {
        name = n;
        arrival = a;
        burst = b;
        priority = p;
        exec = 0;
        departure = arrival;
    }
    public void setDeparture(int d)
    {
        departure = d;
    }
    public void setExec(int e)
    {
        exec = e;
    }
    public string getName()
    {
        return name;
    }
    public int getExec()
    {
        return exec;
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
    public int getWaitingTime()
    {
        waiting = departure - arrival - burst;
        return waiting;
    }
};