using System;
using System.Globalization;
using System.Windows.Forms;
using FXClientSimulator.Properties;

namespace FXClientSimulator {
    public partial class EditConnectionForm : Form {
        private bool _hasChanged;
        private bool _hostHasChanged;
        private bool _portHasChanged;
        private bool _senderHasChanged;
        private bool _targetHasChanged;

        private string _currentHost;
        private string _currentPort;
        private string _currentSender;
        private string _currentTarget;

        public EditConnectionForm() {
            InitializeComponent();

            btnCancel.Select();

            _hasChanged = false;
            _hostHasChanged = false;
            _portHasChanged = false;
            _senderHasChanged = false;
            _targetHasChanged = false;
        }

        private void EditConnectionFormLoad(object sender, EventArgs e) {
            var settings = new Settings();

            txtFixHostMD.Text = settings.FIXHostMD;
            txtFixPortMD.Text = settings.FIXPortMD.ToString(CultureInfo.InvariantCulture);
            txtSenderIdMD.Text = settings.SenderIdMD;
            txtTargetIdMD.Text = settings.TargetIdMD;

            txtFixHostTD.Text = settings.FIXHostTD;
            txtFixPortTD.Text = settings.FIXPortTD.ToString(CultureInfo.InvariantCulture);
            txtSenderIdTD.Text = settings.SenderIdTD;
            txtTargetIdTD.Text = settings.TargetIdTD;

            txtFixHostRFQ.Text = settings.FIXHostRFQ;
            txtFixPortRFQ.Text = settings.FIXPortRFQ.ToString(CultureInfo.InvariantCulture);
            txtSenderIdRFQ.Text = settings.SenderIdRFQ;
            txtTargetIdRFQ.Text = settings.TargetIdRFQ;

            chkAutoConnect.Checked = settings.AutoConnect;

            txtOnBehalfOf.Text = settings.OnBehalfOf;
        }

        #region Form logic
        private void FixHostEnter(object sender) {
            var txtHost = (TextBox) sender;
            _currentHost = txtHost.Text;
            txtHost.SelectAll();
            _hostHasChanged = false;
        }

        private void FixHostLeave(object sender) {
            if (_hostHasChanged) {
                _hasChanged = true;
                return;
            }

            ((TextBox)sender).Text = _currentHost;
        }

        private void FixPortEnter(object sender) {
            var txtPort = (TextBox) sender;
            _currentPort = txtPort.Text;
            txtPort.SelectAll();
            _portHasChanged = false;
        }

        private void FixPortLeave(object sender) {
            var txtPort = (TextBox) sender;
            if (!_portHasChanged) {
                txtPort.Text = _currentPort;
                return;
            }

            int port;

            if (int.TryParse(txtPort.Text, out  port) && (port >= 0 || port < 65535)) {
                _hasChanged = true;
                return;
            }

            txtPort.Text = _currentPort;

            MessageBox.Show(Resources.ApplicationSettings_PortNumbersHelp, Resources.ApplicationSettings_InvalidPort, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            txtPort.Select();
        }

        private void FixSenderIdEnter(object sender) {
            var txtSender = (TextBox) sender;
            _currentSender = txtSender.Text;
            txtSender.SelectAll();
            _senderHasChanged = false;
        }

        private void FixSenderIdLeave(object sender) {
            if (_senderHasChanged) {
                _hasChanged = true;
                return;
            }

            ((TextBox)sender).Text = _currentSender;
        }

        private void FixTargetIdEnter(object sender) {
            var txtTarget = (TextBox) sender;
            _currentTarget = txtTarget.Text;
            txtTarget.SelectAll();
            _targetHasChanged = false;
        }

        private void FixTargetIdLeave(object sender) {
            if (_targetHasChanged) {
                _hasChanged = true;
                return;
            }

            ((TextBox) sender).Text = _currentTarget;
        }
        #endregion

        #region Form buttons
        private void BtnCancelClick(object sender, EventArgs e) {
            if (!_hasChanged) {
                Close();
                return;
            }

            var response = MessageBox.Show(Resources.ApplicationSettings_SaveConnectionSettings, Resources.ApplicationSettings_ConfirmClose, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);

            if (response == DialogResult.Cancel) return;
            
            if (response == DialogResult.No) {
                Close();
                return;
            }

            BtnSaveClick(sender, e);
        }

        private void BtnSaveClick(object sender, EventArgs e) {
            var settings = new Settings {
                                            FIXHostMD = txtFixHostMD.Text, FIXPortMD = int.Parse(txtFixPortMD.Text), SenderIdMD = txtSenderIdMD.Text, TargetIdMD = txtTargetIdMD.Text,
                                            FIXHostTD = txtFixHostTD.Text, FIXPortTD = int.Parse(txtFixPortTD.Text), SenderIdTD = txtSenderIdTD.Text, TargetIdTD = txtTargetIdTD.Text,
                                            FIXHostRFQ = txtFixHostTD.Text, FIXPortRFQ = int.Parse(txtFixPortRFQ.Text), SenderIdRFQ = txtSenderIdRFQ.Text, TargetIdRFQ = txtTargetIdRFQ.Text,
                                            AutoConnect = chkAutoConnect.Checked,
                                            OnBehalfOf = txtOnBehalfOf.Text.Trim()
                                        };
            settings.Save();
            Close();
        }
        #endregion


        #region Market Data Fix Connection Settings

        private void TxtFixHostMDEnter(object sender, EventArgs e) {
            FixHostEnter(sender);
        }

        private void TxtFixHostMDKeyPress(object sender, KeyPressEventArgs e) { _hostHasChanged = true; }

        private void TxtFixHostMDLeave(object sender, EventArgs e) {
            FixHostLeave(sender);
        }

        private void TxtFixPortMDEnter(object sender, EventArgs e) {
            FixPortEnter(sender);
        }

        private void TxtFixPortMDLeave(object sender, EventArgs e) {
            FixPortLeave(sender);
        }

        private void TxtFixPortMDKeyPress(object sender, KeyPressEventArgs e) { _portHasChanged = true; }

        private void TxtSenderIdMDKeyPress(object sender, KeyPressEventArgs e) { _senderHasChanged = true; }

        private void TxtSenderIdMDEnter(object sender, EventArgs e) {
            FixSenderIdEnter(sender);
        }

        private void TxtSenderIdMDLeave(object sender, EventArgs e) {
            FixSenderIdLeave(sender);
        }

        private void TxtTargetIdMDKeyPress(object sender, KeyPressEventArgs e) { _targetHasChanged = true; }

        private void TxtTargetIdMDEnter(object sender, EventArgs e) {
            FixTargetIdEnter(sender);
        }

        private void TxtTargetIdMDLeave(object sender, EventArgs e) {
            FixTargetIdLeave(sender);
        }

        private void TxtFixHostMDClick(object sender, EventArgs e) {
            FixHostEnter(sender);
        }

        private void TxtFixPortMDClick(object sender, EventArgs e) {
            FixPortEnter(sender);
        }

        private void TxtSenderIdMDClick(object sender, EventArgs e) {
            FixSenderIdEnter(sender);
        }

        private void TxtTargetIdMDClick(object sender, EventArgs e) {
            FixTargetIdEnter(sender);
        }

        #endregion

        #region Trade Data Fix Connection Settings
        private void TxtFixHostTDClick(object sender, EventArgs e) {
            FixHostEnter(sender);
        }

        private void TxtFixHostTDEnter(object sender, EventArgs e) {
            FixHostEnter(sender);
        }

        private void TxtFixHostTDLeave(object sender, EventArgs e) {
            FixHostLeave(sender);
        }

        private void TxtFixHostTDKeyPress(object sender, KeyPressEventArgs e) { _hostHasChanged = true; }

        private void TxtFixPortTDClick(object sender, EventArgs e) {
            FixPortEnter(sender);
        }

        private void TxtFixPortTDEnter(object sender, EventArgs e) {
            FixPortEnter(sender);
        }

        private void TxtFixPortTDLeave(object sender, EventArgs e) {
            FixPortLeave(sender);
        }

        private void TxtFixPortTDKeyPress(object sender, KeyPressEventArgs e) { _portHasChanged = true; }

        private void TxtSenderIdTDClick(object sender, EventArgs e) {
            FixSenderIdEnter(sender);
        }

        private void TxtSenderIdTDEnter(object sender, EventArgs e) {
            FixSenderIdEnter(sender);
        }

        private void TxtSenderIdTDLeave(object sender, EventArgs e) {
            FixSenderIdLeave(sender);
        }

        private void TxtSenderIdTDKeyPress(object sender, KeyPressEventArgs e) { _senderHasChanged = true; }

        private void TxtTargetIdTDClick(object sender, EventArgs e) {
            FixTargetIdEnter(sender);
        }

        private void TxtTargetIdTDEnter(object sender, EventArgs e) {
            FixTargetIdEnter(sender);
        }

        private void TxtTargetIdTDLeave(object sender, EventArgs e) {
            FixTargetIdLeave(sender);
        }

        private void TxtTargetIdTDKeyPress(object sender, KeyPressEventArgs e) { _targetHasChanged = true; }
        #endregion

        #region RFQ Fix Connection Settings
        private void TxtFixHostRFQClick(object sender, EventArgs e) {
            FixHostEnter(e);
        }

        private void TxtFixHostRFQEnter(object sender, EventArgs e) {
            FixHostEnter(sender);
        }

        private void TxtFixHostRFQLeave(object sender, EventArgs e) {
            FixHostLeave(sender);        
        }

        private void TxtFixHostRFQKeyPress(object sender, KeyPressEventArgs e) { _hostHasChanged = true; }

        private void TxtFixPortRFQClick(object sender, EventArgs e) {
            FixPortEnter(sender);
        }

        private void TxtFixPortRFQEnter(object sender, EventArgs e) {
            FixPortEnter(sender);
        }

        private void TxtFixPortRFQLeave(object sender, EventArgs e) {
            FixPortLeave(sender);
        }

        private void TxtFixPortRFQKeyPress(object sender, KeyPressEventArgs e) { _portHasChanged = true; }

        private void TxtSenderIdRFQClick(object sender, EventArgs e) {
            FixSenderIdEnter(sender);
        }

        private void TxtSenderIdRFQEnter(object sender, EventArgs e) {
            FixSenderIdEnter(sender);
        }

        private void TxtSenderIdRFQLeave(object sender, EventArgs e) {
            FixSenderIdLeave(sender);
        }

        private void TxtSenderIdRFQKeyPress(object sender, KeyPressEventArgs e) { _senderHasChanged = true; }

        private void TxtTargetIdRFQClick(object sender, EventArgs e) {
            FixTargetIdEnter(sender);
        }

        private void TxtTargetIdRFQEnter(object sender, EventArgs e) {
            FixTargetIdEnter(sender);
        }

        private void TxtTargetIdRFQLeave(object sender, EventArgs e) {
            FixTargetIdLeave(sender);
        }

        private void TxtTargetIdRFQKeyPress(object sender, KeyPressEventArgs e) { _targetHasChanged = true; }
        #endregion

    }
}
