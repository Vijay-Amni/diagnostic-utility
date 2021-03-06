using Renci.SshNet;
using Renci.SshNet.Sftp;
using Renci.SshNet.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace SensorDiagnosticApp
{
    public partial class SensorDiagnostics  : Form
    {
        public string IPAddressMaster;
        public string cmdLine = "python VS_terminal_1.py 1 0";

        public SensorDiagnostics()
        {
           
            InitializeComponent();
            buttlonlist();
            
            
            // Check user type and enable/disable tabs
            // Add startup log
           
            Logger("INFO", "Starting Diagnostics App");

            // Populating the IP Address with default
            txtIP.Text = "192.168.5.100";
        }

        /// <summary>
        /// Function to update logs in the application log tab
        /// </summary>
        /// <param name="logType"></param>
        /// <param name="log"></param>
        public void Logger(string logType, string log)
        {
            Console.WriteLine(Environment.NewLine + logType + ": " + log);
            txtLog.Text += DateTime.Now + " " + logType + ": " + log + Environment.NewLine;
            txtLog.SelectionStart = txtLog.Text.Length;
            txtLog.ScrollToCaret();
        }

        /// <summary>
        /// BackgroundWorker function to update the current value of the progress bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateProgressBar(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// Function to run batch file which connects to the sensor master using putty
        /// and executes the commands in cmds.txt one by one.
        /// Return False on encountering Ntework error
        /// and True on successful execution
        /// </summary>
        /// <returns></returns>
        public string runBatchFile(string cmd)
        {
             IPAddressMaster = txtIP.Text;
            // Using SSH client to connect to the master and  execute the command
            using (SshClient ssh = new SshClient(IPAddressMaster, 22, "root", ""))
            {
                ssh.HostKeyReceived += delegate (object HKsender, HostKeyEventArgs hke)
                {
                    hke.CanTrust = true;
                };
                try
                {
                    ssh.Connect();
                    //var service_stop = ssh.RunCommand("systemctl stop a1fmaster.service");
                    SshCommand cmd1 = ssh.RunCommand(cmd);
                    var response = cmd1.Result;
                    Console.Write(response);
                    ssh.Disconnect();

                    return response;
                }
                catch (SocketException)
                {
                    _ = Invoke((MethodInvoker)delegate { Logger("ERROR", "Could not establish connection with Sensor Master"); });

                    return ("ERROR");
                }
            }
        }

        /// <summary>
        /// This function pings the sensor and displays status in the txtSensorStatus TextBox.
        /// Status will be of three types: Disconnected, Connected P and Connected N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetSensorStatus_Click(object sender, EventArgs e)
        {
            //Disable all buttons to avoid program flow discrepancies
            btnGetSensorStatus.Enabled = false;
            btnGetVoltage.Enabled = false;
            btnGetThresholds.Enabled = false;

            // Save the input from window in a variable
            int sensorNumber;
            string response = "";
            string lastCharacter = "";
            bool found = false;
            bool flag = false;

            // Check if a valid sensor number was given or not, if not then display an alert
            if (int.TryParse(txtSensorNumber.Text, out sensorNumber))
            {
                // Add an entry for requesting sensor status in the log tab
                //Console.WriteLine(string.Format("Retrieving Sensor {0} Status...", sensorNumber));
                Logger("INFO", string.Format("Retrieving Sensor {0} Status", sensorNumber));

                // Generate new command to retrieve sensor status(P/N)
                string newCommand = cmdLine.Split('.')[0] + ".py " + sensorNumber + " 0";

                // Create a new backgroundworker thread which runs the batch file on a different thread
                var bw = new BackgroundWorker();
                bw.WorkerReportsProgress = true;
                bw.ProgressChanged += updateProgressBar;
                // Actual function that does the work on a new thread
                bw.DoWork += delegate
                {
                    bw.ReportProgress(60);

                    // Run batch file
                    response = runBatchFile(newCommand);
                    flag = true;

                    bw.ReportProgress(100);
                };

                // This function will execute when the thread has finished execution
                bw.RunWorkerCompleted += async delegate
                {
                    if (flag)
                    {
                        if (response.Contains("P"))
                        {
                            lastCharacter = "P";
                            found = true;
                        }
                        if (response.Contains("N"))
                        {
                            lastCharacter = "N";
                            found = true;
                        }
                        if (response.Contains("T"))
                        {
                            lastCharacter = "T";
                            found = true;
                        }
                        if (response.Contains("No Reply"))
                        {
                            found = false;
                        }


                        // Check if P/N/No Response
                        if (found)
                        {
                            txtSensorStatus.Text = "Connected " + lastCharacter;
                            Logger("INFO", "Sensor " + sensorNumber + " is connected. Status: " + lastCharacter);
                        }
                        else
                        {
                            txtSensorStatus.Text = "Disconnected";
                            Logger("INFO", "Sensor " + sensorNumber + " is disconnected");
                        }
                    }
                    else
                    {
                        // Display Disconnected if any other response
                        txtSensorStatus.Text = "Network Error";
                        Logger("ERROR", "Network Error! Can't connect to the device");
                    }

                    await Task.Delay(700);
                    progressBar.Value = 0;
                };

                // Start the background thread
                bw.RunWorkerAsync();
            }
            else
            {
                // Prompt user to enter a valid sensor ID and clear the textbox field
                MessageBox.Show("Please Enter a valid Sensor ID.", "Alert");
                txtSensorNumber.Text = "";
            }

            // Enable all buttons
            btnGetSensorStatus.Enabled = true;
            btnGetVoltage.Enabled = true;
            btnGetThresholds.Enabled = true;
        }

        /// <summary>
        /// Function to get the voltage reading in the sensor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetVoltage_Click(object sender, EventArgs e)
        {
            // Save the input from window in a variable
            int sensorNumber;
            string response = "";
            bool flag = false;

            // Check if a valid sensor number was given or not, if not then display an alert
            if (int.TryParse(txtSensorNumber.Text, out sensorNumber))
            {
                // Add an entry for requesting sensor voltage in the log tab
                Logger("INFO", string.Format("Retrieving Sensor {0} Power Information", sensorNumber));

                // Generate new command to retrieve voltage drop
                string newCommand = cmdLine.Split('.')[0] + ".py " + sensorNumber + " 4"; 

                // Create a new backgroundworker thread which will run the batch file on a different thread
                var bw = new BackgroundWorker();
                bw.WorkerReportsProgress = true;
                bw.ProgressChanged += updateProgressBar;
                // Actual function that does the work on a new thread
                bw.DoWork += delegate
                {
                    bw.ReportProgress(60);

                    // Run batch file
                    response = runBatchFile(newCommand);
                    flag = true;

                    bw.ReportProgress(100);
                };

                // This function will execute when the thread has finished execution
                bw.RunWorkerCompleted += async delegate
                {
                    if (flag)
                    {
                        string[] data = response.Split(' ');
                        if (response.Contains("No Reply")|| response.Contains("ERROR"))
                        {
                            Console.WriteLine("No Response from the sensor");
                            txtSensorVoltage.Text = "Disconnected";
                            Logger("ERROR", "Sensor " + sensorNumber + " is disconnected.");
                        }
                        else
                        {
                            Console.WriteLine(data[1]);
                            txtSensorVoltage.Text = data[1] + "V";
                            Logger("INFO", "Sensor " + sensorNumber + " voltage drop: " + data[1] + "V");
                        }
                    }
                    else
                    {
                        // Display Disconnected if any other response
                        txtSensorVoltage.Text = "Network Error";
                        Logger("ERROR", "Network Error! Can't connect to the device");
                    }

                    await Task.Delay(700);
                    progressBar.Value = 0;
                };

                // Start the background thread
                bw.RunWorkerAsync();
            }
            else
            {
                // Prompt user to enter a valid sensor ID and clear the textbox field
                MessageBox.Show("Please Enter a valid Sensor ID.", "Alert");
                txtSensorNumber.Text = "";
            }
        }

        /// <summary>
        /// Function to get the thresholds of a sensor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetThresholds_Click(object sender, EventArgs e)
        {
            // Save the input from window in a variable
            int sensorNumber;
            string response = "";
            bool flag = false;

            // Check if a valid sensor number was given or not, if not then display an alert
            if (int.TryParse(txtSensorNumber.Text, out sensorNumber))
            {
                // Add an entry for requesting current sensor thresholds in the log tab
                Logger("INFO", string.Format("Retrieving Sensor {0} Thresholds", sensorNumber));

                // Generate new command to retrieve voltage drop
                string newCommand = cmdLine.Split('.')[0] + ".py " + sensorNumber + " 2";

                // Create a new backgroundworker thread which will run the batch file on a different thread
                var bw = new BackgroundWorker();
                bw.WorkerReportsProgress = true;
                bw.ProgressChanged += updateProgressBar;
                // Actual function that does the work on a new thread
                bw.DoWork += delegate
                {
                    bw.ReportProgress(60);

                    // Run batch file
                    response = runBatchFile(newCommand);
                    if (response.Contains("No Reply"))
                    {
                        flag = false;
                    }
                    else
                    {
                        flag = true;
                    }
                    bw.ReportProgress(100);
                };

                // This function will execute when the thread has finished execution
                bw.RunWorkerCompleted += async delegate
                {
                    if (flag)
                    {
                        string[] data = response.Split(' ');

                        try
                        {
                            txtStddr.Text = data[1];
                            txtRstddr.Text = data[2];
                            txtMaxRate.Text = data[3];
                            Logger("INFO", "Sensor " + sensorNumber + " thresholds: " + data[1] + " " + data[2] + " " + data[3]);
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("No Response from the sensor");
                            txtStddr.Text = "NA";
                            txtRstddr.Text = "NA";
                            txtMaxRate.Text = "NA";
                            Logger("ERROR", "Sensor " + sensorNumber + " data error");
                        }
                    }
                    else
                    {
                        // Display Disconnected if any other response
                        txtStddr.Text = "NA";
                        txtRstddr.Text = "NA";
                        txtMaxRate.Text = "NA";
                        Logger("ERROR", "Network Error! Can't connect to the device");
                    }

                    await Task.Delay(700);
                    progressBar.Value = 0;
                };

                // Start the background thread
                bw.RunWorkerAsync();
            }
            else
            {
                // Prompt user to enter a valid sensor ID and clear the textbox field
                MessageBox.Show("Please Enter a valid Sensor ID.", "Alert");
                txtSensorNumber.Text = "";
            }
        }

        private void btnClearLogs_Click(object sender, EventArgs e)
        {
            if (txtLog.Text != "")
            {
                txtLog.Clear();
            }
        }

        private void btnExportLogs_Click(object sender, EventArgs e)
        {
            // Check if there are any logs to be exported
            if (txtLog.Text == "")
            {
                Logger("ERROR", "There are no logs to be exported");
                return;
            }
            else
            {
                // Since there are logs to be exported, continue execution and enable the clear logs button
                btnClearLogs.Enabled = true;
            }

            // Log the export event
            Logger("INFO", "Exporting application logs");
            bool flag = false;
            string[] logData = txtLog.Lines;

            // Create a background worker thread to export the logs
            var bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            bw.ProgressChanged += updateProgressBar;
            // Actual function that does the work on a new thread
            bw.DoWork += delegate
            {
                // This will get the current WORKING directory (i.e. \bin\Debug)
                string workingDirectory = Environment.CurrentDirectory;

                // Append today's date to the log file name
                string fileName = string.Format("{0:dd-MM-yyyy}_log.txt", DateTime.Now);

                // This will create the complete log file filepath
                string logFileName = System.IO.Path.GetFullPath(workingDirectory + @"\logs\" + fileName);

                // Boolean flag to check if file exists or not
                flag = File.Exists(logFileName);

                // Check if a log file already exists in the given path, if not create a new file
                if (!flag)
                {
                    // check if the log folder exists. if not, create a new folder
                    Directory.CreateDirectory(workingDirectory + @"\logs");

                    // Create a new file with the required name
                    using (StreamWriter sw = File.CreateText(logFileName))
                    {
                        // Add a general header to the log file
                        sw.WriteLine("Daily Logs: {0:dd-MM-yyyy}", DateTime.Now);
                        // Write data to the log file
                        foreach (string log in logData)
                        {
                            sw.WriteLine(log);
                        }
                    }
                }
                else if (flag)
                {
                    // This statement opens the file for adding more lines to an already existing file
                    using (StreamWriter sw = File.AppendText(logFileName))
                    {
                        // if log file already exists, write data from the application logs to the log file
                        foreach (string log in logData)
                        {
                            sw.WriteLine(log);
                        }
                    }
                }
            };

            // Log the events after logs have been exported
            bw.RunWorkerCompleted += delegate
            {
                if (flag)
                {
                    Logger("INFO", "Log File Found. Updated.");
                }
                else
                {
                    Logger("INFO", "Created a new log file");
                }
            };
            // Start the logging thread
            bw.RunWorkerAsync();
        }

        private void btnOpenLogs_Click(object sender, EventArgs e)
        {
            // This will get the current WORKING directory (i.e. \bin\Debug)
            string workingDirectory = Environment.CurrentDirectory;

            // Append today's date to the log file name
            string fileName = string.Format("{0:dd-MM-yyyy}_log.txt", DateTime.Now);

            // This will create the complete log file filepath
            string logFileName = System.IO.Path.GetFullPath(workingDirectory + @"\logs\" + fileName);

            // Open a notepad to view the log file
            if (File.Exists(logFileName))
            {
                Process.Start("notepad.exe", logFileName);
            }
            else
            {
                MessageBox.Show("No Log File Found.", "Alert");
            }
        }

         /// Function to ping a range of sensors and return a list of all the available sensors
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPingSensors_Click(object sender, EventArgs e)
        {
            // Save the input from window in a variable
            int start_range, end_range;
            string response = "";
            List<string> listOfSensors = new List<string>();

            // Check if a valid range was given or not, if not then display an alert
            if (int.TryParse(txtPingEnd.Text, out end_range) && int.TryParse(txtPingStart.Text, out start_range))
            {
                // Add log entry to specify the start
                Logger("INFO", "Pinging sensors " + start_range + " to " + end_range);

                // Create a new backgroundworker thread which will run the batch file multiple times on a different thread
                var bw = new BackgroundWorker();
                bw.WorkerReportsProgress = true;
                bw.ProgressChanged += updatePingProgressBar;
                bw.DoWork += delegate
                {
                    for (int i = start_range; i <= end_range; i++)
                    {
                        // Generate new command to ping sensor
                        string newCommand = cmdLine.Split('.')[0] + ".py " + i + " 0";

                        response = runBatchFile(newCommand);

                        if (response == "")
                        {
                            // Break if there's a network error
                            break;
                        }
                        else
                        {
                            if (response.Contains("No"))
                            {
                                continue;
                            }
                            // Check if P/N/No Response
                            else if (response.Contains("P") || response.Contains("N") || response.Contains("T"))
                            {
                                listOfSensors.Add(i.ToString());
                            }

                            // update progress bar for every sensor pinged
                            bw.ReportProgress((i-start_range) * 100 / (end_range-start_range));
                        }
                    }
                };
                bw.RunWorkerCompleted += async delegate
                {
                    if (response == "")
                    {
                        Logger("ERROR", "Network Error! Can't connect to the device");
                    }
                    else
                    {
                        // Reset the listbox so that new data can be entered
                        listSensors.Items.Clear();

                        // Add all the available sensors to the listbox
                        foreach (string s in listOfSensors)
                        {
                            listSensors.Items.Add(s);
                        }
                        Logger("INFO", "Preparing list of available sensors");
                    }

                    await Task.Delay(700);
                    progressBar.Value = 0;
                };
                bw.RunWorkerAsync();
            }
            else
            {
                // Prompt user to enter a valid range and reset the textbox field
                MessageBox.Show("Please Enter a valid Sensor ID Range.", "Alert");
                txtPingEnd.Text = "Range";
            }
        }

        // Custom update progress bar function for pinging all the sensors
        private void updatePingProgressBar(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            Logger("INFO", "Ping Status: " + e.ProgressPercentage + "%");
        }

        private void listSensors_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSensorNumber.Text = listSensors.SelectedItem.ToString();
        }

        private void txtPingRange_Enter(object sender, EventArgs e)
        {
            txtPingEnd.Text = string.Empty;
        }

        private void txtPingRange_Leave(object sender, EventArgs e)
        {
            if (txtPingEnd.Text == string.Empty)
            {
                txtPingEnd.Text = "END";
            }
        }

        /// <summary>
        /// Function to get raw data of a sensor and plot them in corresponding graphs for analysis
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetRawData_Click(object sender, EventArgs e)
        {
            // Save the input from window in a variable
            int sensorNumber;
            int samples;
            float qTime;
            var response = "";
            bool flag = false;

            // Check if a valid sensor number was given or not, if not then display an alert
            if (int.TryParse(txtSensorNumber.Text, out sensorNumber) && int.TryParse(txtSamples.Text, out samples) && float.TryParse(txtQueueTime.Text, out qTime))
            {
                // Add an entry for requesting sensor raw data in the log tab
                Logger("INFO", string.Format("Retrieving Sensor {0} Raw Data", sensorNumber));

                // Generate new command to retrieve sensor raw data
                string newCommand = cmdLine.Split('.')[0] + ".py " + sensorNumber + " 1 " + samples + " " + qTime;

                // Create a new backgroundworker thread which runs the batch file on a different thread
                var bw = new BackgroundWorker();
                bw.WorkerReportsProgress = true;
                bw.ProgressChanged += updateProgressBar;
                // Actual function that does the work on a new thread
                bw.DoWork += delegate
                {
                    bw.ReportProgress(60);

                    // Run batch file
                    response = runBatchFile(newCommand);
                    flag = true;

                    bw.ReportProgress(100);
                };
                // This function will execute when the thread has finished execution
                bw.RunWorkerCompleted += async delegate
                {
                    if (flag)
                    {
                        if (response.Contains("No Reply") || response.Contains("ERROR"))
                        {
                            Logger("ERROR", "Sensor " + sensorNumber + " is not connected.");
                        }
                        else
                        {
                            // Create new datatable
                            var table = new DataTable();

                            // Create string array from response string
                            string[] data = response.Split('\n');

                            // Split the space delimited rows into individual strings and store in an array
                            var splitFileContents = (from f in data select f.Split(' ')).ToArray();

                            // Get the max length of the data table
                            int maxLength = (from s in splitFileContents select s.Count()).Max();

                            // Add columns to the table
                            for (int i = 0; i < maxLength; i++)
                            {
                                table.Columns.Add();
                            }

                            // Add data to Datatable
                            foreach (var line in splitFileContents)
                            {
                                DataRow row = table.NewRow();
                                row.ItemArray = line;
                                table.Rows.Add(row);
                            }
                            // Remove last column which has only blank spaces and CRC
                            table.Columns.RemoveAt(table.Columns.Count - 1);
                            table.Columns.RemoveAt(table.Columns.Count - 1);

                            // Display the datatable
                            RawData rd = new RawData(table);
                            rd.Show();
                        }
                    }
                    else
                    {
                        // Display Disconnected if any other response
                        txtSensorStatus.Text = "Network Error";
                        Logger("ERROR", "Network Error! Can't connect to the device");
                    }

                    // Wait for some time and reset the progress bar
                    await Task.Delay(700);
                    progressBar.Value = 0;
                };

                // Start the thread to get raw data
                bw.RunWorkerAsync();
            }
            else
            {
                // Prompt user to enter a valid sensor ID, no. of samples or Queue Time and clear the textbox field
                MessageBox.Show("Please Enter a valid Sensor ID, No. of Sample and Queue Time.", "Alert");
                txtSensorNumber.Text = "";
            }
        }

        /// <summary>
        /// Function to update thresholds of a sensor and return the updated thresholds
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetThresholds_Click(object sender, EventArgs e)
        {
            // Save the input from window in a variable
            int sensorNumber;
            float setStddr;
            float setRstddr;
            int setMaxRate;
            int flagStddr = 0;
            int flagRstddr = 0;
            int flagMaxRate = 0;
            string response = "";

            // Check if a valid sensor number was given or not, if not then display an alert
            if (int.TryParse(txtSensorNumber.Text, out sensorNumber))
            {
                // Add an entry for setting new sensor thresholds in the log tab
                Logger("INFO", string.Format("Updating Sensor {0} Setpoints", sensorNumber));

                // Create a new backgroundworker thread which runs the batch file on a different thread
                var bw = new BackgroundWorker();
                bw.WorkerReportsProgress = true;
                bw.ProgressChanged += updateProgressBar;
                // Actual function that does the work on a new thread
                bw.DoWork += delegate
                {

                    bw.ReportProgress(10);

                    // Set STDDR
                    if (float.TryParse(txtSetStddr.Text, out setStddr))
                    {

                        // Generate new command to set stddr value
                        string newCommand = cmdLine.Split('.')[0] + ".py " + sensorNumber + " 5 " + setStddr;

                        // Run batch file
                        response = runBatchFile(newCommand);
                        flagStddr = 1;
                    }
                    else if (txtSetStddr.Text == "")
                    {
                        flagStddr = 3;
                    }
                    bw.ReportProgress(40);

                    // Set RSTDDR
                    if (float.TryParse(txtSetRstddr.Text, out setRstddr))
                    {

                        // Generate new command to set stddr value
                        string newCommand = cmdLine.Split('.')[0] + ".py " + sensorNumber + " 7 " + setRstddr;

                        response = runBatchFile(newCommand);
                        flagRstddr = 1;
                    }
                    else if (txtSetRstddr.Text == "")
                    {
                        flagRstddr = 3;
                    }
                    bw.ReportProgress(60);

                    // Set MAX RATE
                    if (int.TryParse(txtSetMaxRate.Text, out setMaxRate))
                    {

                        // Generate new command to set stddr value
                        string newCommand = cmdLine.Split('.')[0] + ".py " + sensorNumber + " 9 " + setMaxRate;

                        response = runBatchFile(newCommand);
                        flagMaxRate = 1;
                    }
                    else if (txtSetMaxRate.Text == "")
                    {
                        flagMaxRate = 3;
                    }
                    bw.ReportProgress(100);
                };
                // This function will execute when the thread has finished execution
                bw.RunWorkerCompleted += async delegate
                {
                    // Set flags if setpoints are updated or not
                    if (flagStddr == 1)
                    {
                        Logger("INFO", "Sensor stddr setpoint updated");
                    }
                    else if (flagStddr == 2)
                    {
                        Logger("ERROR", "Sensor stddr setpoint not updated");
                    }

                    if (flagRstddr == 1)
                    {
                        Logger("INFO", "Sensor rstddr setpoint updated");
                    }
                    else if (flagRstddr == 2)
                    {
                        Logger("ERROR", "Sensor rstddr setpoint not updated");
                    }

                    if (flagMaxRate == 1)
                    {
                        Logger("INFO", "Sensor max rate setpoint updated");
                    }
                    else if (flagMaxRate == 2)
                    {
                        Logger("ERROR", "Sensor max rate setpoint not updated");
                    }

                    // Check if any gibberish value was entered
                    if (flagStddr == 0 || flagRstddr == 0 || flagMaxRate == 0)
                    {
                        MessageBox.Show("Invalid Data was entered, Please recheck setpoints.", "Alert");
                    }

                    // Clear text fields
                    txtSetStddr.Text = "";
                    txtSetRstddr.Text = "";
                    txtSetMaxRate.Text = "";

                    // Wait for some time and reset the progress bar
                    await Task.Delay(700);
                    progressBar.Value = 0;

                    // Refresh the current thresholds in the Window
                    btnGetThresholds_Click(sender, e);
                };

                // Start the thread to update relevent setpoints
                bw.RunWorkerAsync();
            }
            else
            {
                // Prompt user to enter a valid sensor ID and setpoints in proper format
                MessageBox.Show("Please Enter a valid Sensor ID and relevant data.", "Alert");
                txtSensorNumber.Text = "";
            }
        }

        private void TxtPingStart_Enter(object sender, EventArgs e)
        {
            txtPingStart.Text = string.Empty;
        }

        private void TxtPingStart_Leave(object sender, EventArgs e)
        {
            if (txtPingStart.Text == string.Empty)
            {
                txtPingStart.Text = "START";
            }
        }

        /// <summary>
        /// Function to change the sensor ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnChangeSensorID_Click(object sender, EventArgs e)
        {
            // Save the input from window in a variable
            int oldSensorNumber, newSensorNumber;
            string response = "";
            bool flag = false;

            // Check if a valid sensor number was given or not, if not then display an alert
            if (int.TryParse(txtOldSensorID.Text, out oldSensorNumber) && int.TryParse(txtNewSensorID.Text, out newSensorNumber))
            {
                // Add an entry for changing sensor id in the log tab
                Logger("INFO", string.Format("Changing ID of Sensor {0} to {1}", oldSensorNumber, newSensorNumber));

                // Generate new command to change the sensor id
                string newCommand = cmdLine.Split('.')[0] + ".py " + oldSensorNumber + " 3 " + newSensorNumber;

                // Create a new backgroundworker thread which runs the batch file on a different thread
                var bw = new BackgroundWorker();
                bw.WorkerReportsProgress = true;
                bw.ProgressChanged += updateProgressBar;
                // Actual function that does the work on a new thread
                bw.DoWork += delegate
                {
                    bw.ReportProgress(60);

                    // Run batch file
                    response = runBatchFile(newCommand);
                    flag = true;

                    bw.ReportProgress(100);
                };

                // This function will execute when the thread has finished execution
                bw.RunWorkerCompleted += async delegate
                {
                    if (flag)
                    {
                        txtChangeStatus.Text = response;

                        // Check the operation Response
                        if (response.Contains("ok"))
                        {
                            txtChangeStatus.Text = "ID changed successfully.";
                            Logger("INFO", "Sensor ID of " + oldSensorNumber + " was changed to " + newSensorNumber);
                        }
                        else if (response.Contains("No Reply"))
                        {
                            txtChangeStatus.Text = "The given sensor ID does not exist/Disconnected.";
                            Logger("INFO", "Sensor ID of " + oldSensorNumber + " could not be changed as the given sensor ID is not connected.");
                        }
                        else if (response.Contains("P") || response.Contains("N") || response.Contains("T"))
                        {
                            txtChangeStatus.Text = "New ID already exists.";
                            Logger("INFO", "Sensor ID of " + oldSensorNumber + " could not be changed as the sensor ID already exists.");
                        }   
                    }
                    else
                    {
                        // Display Disconnected if any other response
                        txtChangeStatus.Text = "Network Error";
                        Logger("ERROR", "Network Error! Can't connect to the device");
                    }

                    await Task.Delay(700);
                    progressBar.Value = 0;
                };

                // Start the background thread
                bw.RunWorkerAsync();
            }
            else
            {
                // Prompt user to enter a valid sensor ID and clear the textbox field
                MessageBox.Show("Please Enter a valid Sensor IDs.", "Alert");
                txtChangeStatus.Text = "";
            }
        }

        private void BtnStartService_Click(object sender, EventArgs e)
        {
            IPAddressMaster = txtIP.Text;
            // Using SSH client to connect to the master and start the service
            using (SshClient ssh = new SshClient(IPAddressMaster, 22, "root", ""))
            {
                try
                {
                    ssh.Connect();
                    var service_stop = ssh.RunCommand("systemctl start a1fmaster.service");
                    var response = service_stop.Result;
                    Console.Write(response);
                    ssh.Disconnect();
                    Logger("INFO", "Service has been started in the Sensor Master");
                    return;
                }
                catch (SocketException)
                {
                    Logger("ERROR", "Could not establish connection with Sensor Master");
                    return;
                }
            }
        }

        private void BtnStopService_Click(object sender, EventArgs e)
        {
            IPAddressMaster = txtIP.Text;
            // Using SSH client to connect to the master and stop the service
            using (SshClient ssh = new SshClient(IPAddressMaster, 22, "root", ""))
            {
                try
                {
                    ssh.Connect();
                    var service_stop = ssh.RunCommand("systemctl stop a1fmaster.service");
                    var response = service_stop.Result;
                    Console.Write(response);
                    ssh.Disconnect();
                    Logger("INFO", "Service has been stopped in the Sensor Master");
                    buttlonlist();
                    return;
                }
                catch (SocketException)
                {
                    Logger("ERROR", "Could not establish connection with Sensor Master");
                    return;
                }
                
            }
        }

        private void BtnReboot_Click(object sender, EventArgs e)
        {
            IPAddressMaster = txtIP.Text;
            // Using SSH client to connect to the master and reboot the master
            using (SshClient ssh = new SshClient(IPAddressMaster, 22, "root", ""))
            {
                try
                {
                    ssh.Connect();
                    var service_stop = ssh.RunCommand("reboot");
                    var response = service_stop.Result;
                    Console.Write(response);
                    ssh.Disconnect();
                    return;
                }
                catch (SocketException)
                {
                    Logger("ERROR", "Could not establish connection with Sensor Master");
                    return;
                }
                catch (Renci.SshNet.Common.SshConnectionException)
                {
                    Logger("INFO", "Sensor Master is rebooting");
                    return;
                }
            }
        }

        private void BtnBatchUpdate_Click(object sender, EventArgs e)
        {
            IPAddressMaster = txtIP.Text;
            // Using SSH client to connect to the master and  execute the command
            using (SshClient ssh = new SshClient(IPAddressMaster, 22, "root", ""))
            {
                ssh.HostKeyReceived += delegate (object HKsender, HostKeyEventArgs hke)
                {
                    hke.CanTrust = true;
                };
                try
                {
                    ssh.Connect();
                    //var service_stop = ssh.RunCommand("systemctl stop a1fmaster.service");

                    //variables for running the loop
                    int batchStartNumber;
                    int batchEndNumber;

                    //input variables and flags
                    float setStddr;
                    float setRstddr;
                    int setMaxRate;
                    int flagStddr = 0;
                    int flagRstddr = 0;
                    int flagMaxRate = 0;
                    string response = "";
                    SshCommand cmd;

                    // Check if a valid sensor number was given or not, if not then display an alert
                    if (int.TryParse(txtBatchUpdateStart.Text, out batchStartNumber) && int.TryParse(txtBatchUpdateEnd.Text, out batchEndNumber)
                        && (batchStartNumber<batchEndNumber))
                    {
                        // Add an entry for setting new sensor thresholds in the log tab
                        Logger("INFO", string.Format("Updating Setpoints from Sensor {0} to {1} ", batchStartNumber, batchEndNumber));

                        for (int id = batchStartNumber; id <= batchEndNumber; id++)
                        {
                            // Set STDDR
                            if (float.TryParse(txtSetStddr.Text, out setStddr))
                            {

                                // Generate new command to set stddr value
                                string newCommand = cmdLine.Split('.')[0] + ".py " + id + " 5 " + setStddr;

                                // Run console command on ssh client
                                cmd = ssh.RunCommand(newCommand);
                                response = cmd.Result;

                                // Check for ok response from the sensor
                                if (response.Contains("ok"))
                                {
                                    flagStddr = 1;
                                }
                                else
                                {
                                    flagStddr = 2;
                                }
                            }
                            else if (txtSetStddr.Text == "")
                            {
                                flagStddr = 3;
                            }

                            // Set RSTDDR
                            if (float.TryParse(txtSetRstddr.Text, out setRstddr))
                            {

                                // Generate new command to set stddr value
                                string newCommand = cmdLine.Split('.')[0] + ".py " + id + " 7 " + setRstddr;

                                // Run console command on ssh client
                                cmd = ssh.RunCommand(newCommand);
                                response = cmd.Result;

                                // Check for ok response from the sensor
                                if (response.Contains("ok"))
                                {
                                    flagRstddr = 1;
                                }
                                else
                                {
                                    flagRstddr = 2;
                                }
                            }
                            else if (txtSetRstddr.Text == "")
                            {
                                flagRstddr = 3;
                            }

                            // Set MAX RATE
                            if (int.TryParse(txtSetMaxRate.Text, out setMaxRate))
                            {

                                // Generate new command to set stddr value
                                string newCommand = cmdLine.Split('.')[0] + ".py " + id + " 9 " + setMaxRate;

                                // Run console command on ssh client
                                cmd = ssh.RunCommand(newCommand);
                                response = cmd.Result;

                                // Check for ok response from the sensor
                                if (response.Contains("ok"))
                                {
                                    flagMaxRate = 1;
                                }
                                else
                                {
                                    flagMaxRate = 2;
                                }
                            }
                            else if (txtSetMaxRate.Text == "")
                            {
                                flagMaxRate = 3;
                            }

                            // Set flags if setpoints are updated or not
                            if (flagStddr == 1)
                            {
                                Logger("INFO", "Sensor " + id + " stddr setpoint updated");
                            }
                            else if (flagStddr == 2)
                            {
                                Logger("ERROR", "Sensor " + id + " stddr setpoint not updated");
                            }

                            if (flagRstddr == 1)
                            {
                                Logger("INFO", "Sensor " + id + " rstddr setpoint updated");
                            }
                            else if (flagRstddr == 2)
                            {
                                Logger("ERROR", "Sensor " + id + " rstddr setpoint not updated");
                            }

                            if (flagMaxRate == 1)
                            {
                                Logger("INFO", "Sensor " + id + " max rate setpoint updated");
                            }
                            else if (flagMaxRate == 2)
                            {
                                Logger("ERROR", "Sensor " + id + " max rate setpoint not updated");
                            }

                            // Check if any gibberish value was entered
                            if (flagStddr == 0 || flagRstddr == 0 || flagMaxRate == 0)
                            {
                                MessageBox.Show("Invalid Data was entered, Please recheck setpoints.", "Alert");
                            }
                        }

                        // Clear text fields
                        txtSetStddr.Text = "";
                        txtSetRstddr.Text = "";
                        txtSetMaxRate.Text = "";

                        //disconnect SSH client
                        ssh.Disconnect();
                    }
                    else
                    {
                        // Prompt user to enter a valid sensor ID and setpoints in proper format
                        MessageBox.Show("Please Enter a valid Sensor IDs and relevant data.", "Alert");
                    }
                }
                catch (SocketException)
                {
                    Logger("ERROR", "Could not establish connection with Sensor Master");
                }
            }
        }

        private void TxtBatchUpdateStart_Enter(object sender, EventArgs e)
        {
            txtBatchUpdateStart.Text = "";
        }

        private void TxtBatchUpdateStart_Leave(object sender, EventArgs e)
        {
            if (txtBatchUpdateStart.Text == String.Empty)
            {
                txtBatchUpdateStart.Text = "START";
            }
        }

        private void TxtBatchUpdateEnd_Enter(object sender, EventArgs e)
        {
            txtBatchUpdateEnd.Text = "";
        }

        private void TxtBatchUpdateEnd_Leave(object sender, EventArgs e)
        {
            if (txtBatchUpdateEnd.Text == String.Empty)
            {
                txtBatchUpdateEnd.Text = "END";
            }
        }

        private void TxtFirmwareStart_Enter(object sender, EventArgs e)
        {
            txtFirmwareStart.Text = "";
        }

        private void TxtFirmwareStart_Leave(object sender, EventArgs e)
        {
            if (txtFirmwareStart.Text == String.Empty)
            {
                txtFirmwareStart.Text = "START";
            }
        }

        private void TxtFirmwareEnd_Enter(object sender, EventArgs e)
        {
            txtFirmwareEnd.Text = "";
        }

        private void TxtFirmwareEnd_Leave(object sender, EventArgs e)
        {
            if (txtFirmwareEnd.Text == String.Empty)
            {
                txtFirmwareEnd.Text = "END";
            }
        }

        /// <summary>
        /// Browse function opens a dialog from where the user can select the .bin file
        /// and the file location will be stored in a property. This file location will be 
        /// used later by the upload function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog browseDialog = new OpenFileDialog();
            browseDialog.Filter = "Binary Files (*.bin)|*.bin| All Files(*.*)|*.*";

            if (browseDialog.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = browseDialog.FileName;

                Logger("INFO", "Firmware file selected: " + txtFileName.Text);
            }
        }

        /// <summary>
        /// This function will upload the binary file to the Sensor Master
        /// using scp command and then use ssh to run the modboot application
        /// It will run for every sensor in the range specified by the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnUpload_Click(object sender, EventArgs e)
        {
            string fileLocation = txtFileName.Text;

            // this command will transfer the binary file into the sensor master
            // scp <filename> root@<IP>:/home/root/
            // this command will change the firmware file permissions
            // chmod +x <filename>
            string host = txtIP.Text;
            string username = "root";
            string password = "";
            string remoteDirectory = "/home/root/";

            using (SftpClient sftp = new SftpClient(host, username, password))
            {
                sftp.HostKeyReceived += delegate (object HKsender, HostKeyEventArgs hke)
                {
                    hke.CanTrust = true;
                };
                try
                {
                    Logger("INFO", "Making SFTP connection to the sensor master");
                    // connecting to the master
                    sftp.Connect();

                    Logger("INFO", "Uploading file from location: " + fileLocation);
                    // giving the file info of the binary file to be uploaded
                    FileInfo f = new FileInfo(fileLocation);
                    string uploadfile = f.FullName;

                    // making sftp connection
                    var client = new SftpClient(host, username, password);
                    client.Connect();
                    if (client.IsConnected)
                    {
                        Logger("INFO", "SFTP connected");
                    }

                    // uploading file
                    var fileStream = new FileStream(uploadfile, FileMode.Open);
                    if (fileStream != null)
                    {
                        Logger("INFO", "FileStream Aquired");
                    }
                    client.BufferSize = 4 * 1024;
                    client.UploadFile(fileStream, remoteDirectory + f.Name, null);

                    client.Disconnect();
                    client.Dispose();

                    // use runBatchFile to run the chmod command
                    this.Invoke((MethodInvoker)delegate {runBatchFile("chmod +x " + f.Name);});
                    Logger("INFO", "Changing File Permissions");

                    int firmwareStartNumber;
                    int firmwareEndNumber;
                    // run the bootloader for all the sensors in the specified range
                    // display output to the Logger and handle errors
                    // Check if a valid sensor number was given or not, if not then display an alert
                    if (int.TryParse(txtFirmwareStart.Text, out firmwareStartNumber) && int.TryParse(txtFirmwareEnd.Text, out firmwareEndNumber)
                        && (firmwareStartNumber < firmwareEndNumber))
                    {
                        // Add an entry for setting new sensor thresholds in the log tab
                        Logger("INFO", string.Format("Updating Firmware from Sensor {0} to {1} ", firmwareStartNumber, firmwareEndNumber));

                        for (int id = firmwareStartNumber; id <= firmwareEndNumber; id++)
                        {
                            // response string
                            string response = "";
                            Logger("INFO", string.Format("Updating Firmware of sensor {0}", id));

                            Invoke((MethodInvoker)delegate { response = runBatchFile("./modboot " + f.Name + " " + id); });
                            Logger("INFO", response);
                            Invoke((MethodInvoker)delegate { response = runBatchFile("python VS_terminal_1.py "+ (id+1) + " 0"); });
                            //Logger("INFO", response);
                        }
                    }
                    else
                    {
                        // Prompt user to enter a valid sensor IDs
                        MessageBox.Show("Please enter valid Sensor IDs.", "Alert");
                        txtFirmwareStart.Text = "START";
                        txtFirmwareEnd.Text = "END";
                    }
                }
                catch (Exception ex)
                {
                    Logger("ERROR", ex.Message);
                }
            }

        }

        private void BtnChangeIP_Click(object sender, EventArgs e)
        {
            string oldIPAddress = txtIP.Text;
            string newIPAddress = txtChangeIP.Text;

            IPAddress ip;
            // Check if the IP address entered is a valid IP address
            bool validIPFlag = IPAddress.TryParse(txtChangeIP.Text, out ip);

            // check if IP Address has 4 digits and change flag if not
            string[] digits = newIPAddress.Split('.');
            if (digits.Length < 4)
            {
                validIPFlag = false;
            }
            else if( digits[0] != "192" || digits[1] != "168" || digits[2] != "5")
            {
                validIPFlag = false;
            }

            if (validIPFlag)
            {
                Logger("INFO", "Valid IP Address found, making connection to the sensor master");
            }
            else
            {
                Logger("ERROR", "Please enter a valid IP address and try again");
                return;
            }
            
            Action runCommand = () =>
            {
                try
                {
                    using (SshClient ssh = new SshClient(oldIPAddress, 22, "root", ""))
                    {
                        ssh.Connect();
                        var changeIPCommmand = ssh.RunCommand("ifconfig eth0 " + newIPAddress + " netmask 255.255.255.0");
                        var response = changeIPCommmand.Result;
                    }
                }
                catch (SocketException)
                {
                    Invoke((MethodInvoker)delegate { Logger("ERROR", "Could not establish connection with Sensor Master"); });
                    return;
                }
                finally
                {
                    Invoke((MethodInvoker)delegate { Logger("INFO", "Sensor Master IP Address updated to " + newIPAddress + "\n Connect using the new IP Address to continue Diagnostics."); });
                }
            };
            ThreadPool.QueueUserWorkItem(x => runCommand());
            return;
        }

        private void buttlonlist()
        {

           // List<GroupBox> Gboxlist = this.Controls.OfType<GroupBox>().Where(a=>a.Name.StartsWith("Group")).ToList();
          //  List<Button> lColors = this.Controls.OfType<Button>().Concat(this.gr.Controls.OfType<Button>()).Concat(this.groupBox3.Controls.OfType<Button>()).ToList();
          List<string> list = this.
           // List<Button> listbtn = this.Controls.OfType<Button>().Where(a => a.Name.StartsWith("btn")).ToList();          
        }
    }
}
