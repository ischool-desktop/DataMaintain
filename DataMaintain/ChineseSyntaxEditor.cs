using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ActiproSoftware.SyntaxEditor;

namespace DataMaintain
{
    public class ChineseSyntaxEditor : SyntaxEditor
    {
        private FindReplaceForm _find_replace_form;

        public ChineseSyntaxEditor()
        {
            Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
        }

        protected override void OnKeyTyping(KeyTypingEventArgs e)
        {
            base.OnKeyTyping(e);

            if (e.Cancel) return;

            if (e.KeyData == (Keys.Control | Keys.F))
            {
                if (_find_replace_form == null)
                    _find_replace_form = new FindReplaceForm(this, new FindReplaceOptions());

                if (TopLevelControl is Form)
                    _find_replace_form.Owner = TopLevelControl as Form;

                _find_replace_form.Show();
            }
        }
    }
}
