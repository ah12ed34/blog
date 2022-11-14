using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace blog.tools
{
    internal class ToolsMessages
    {
        private MessageBoxIcon iconMessage = MessageBoxIcon.Exclamation;
        private MessageBoxButtons ButtonMessage = MessageBoxButtons.AbortRetryIgnore;

        public DialogResult Message(string title,string mass,IconName icon=IconName.Warning,ButtonName ButtonName =ButtonName.ok)
        {
            switch (icon)
            {
                case IconName.Asterisk: iconMessage = MessageBoxIcon.Asterisk; break;
                case IconName.error: iconMessage = MessageBoxIcon.Error;       break;
                case IconName.Exclamation : iconMessage = MessageBoxIcon.Exclamation; break;
                case IconName.Hand : iconMessage = MessageBoxIcon.Hand;               break;
                case IconName.Information : iconMessage = MessageBoxIcon.Information;        break;
                case IconName.Question: iconMessage = MessageBoxIcon.Question;           break;
                case IconName.Stop : iconMessage = MessageBoxIcon.Stop;               break;
                case IconName.Warning: iconMessage = MessageBoxIcon.Warning;         break;
            }

            switch (ButtonName) {
                case ButtonName.ok:
                ButtonMessage = MessageBoxButtons.OK;break;
                case ButtonName.OKCancel:
                ButtonMessage = MessageBoxButtons.OKCancel;break;
                case ButtonName.YesNoCancel:
                ButtonMessage = MessageBoxButtons.YesNoCancel;break;
                case ButtonName.RetryCancel:
                ButtonMessage = MessageBoxButtons.RetryCancel;break;
                case ButtonName.YesNo:
                ButtonMessage = MessageBoxButtons.YesNo;break;
                case ButtonName.AbortRetryIgnore:
                ButtonMessage = MessageBoxButtons.AbortRetryIgnore;
                    break;
        }
         return MessageBox.Show(mass,title,ButtonMessage,iconMessage);
        }


      public enum IconName { error , Asterisk , Exclamation , Hand, Information, Question, Stop, Warning }  
      public enum ButtonName { ok , AbortRetryIgnore , OKCancel, YesNoCancel, RetryCancel, YesNo}  
    }
}
