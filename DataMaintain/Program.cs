using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FISCA;
using FISCA.Data;
using FISCA.Presentation;

namespace DataMaintain
{
    public static class Program
    {
        [MainMethod]
        public static void Main()
        {
            if (!FISCA.Authentication.DSAServices.IsSysAdmin)
                return;

            if (!RTContext.IsDiagMode)
                return;

            MotherForm.AddPanel(SQLEditor.Window);

            SQLEditor.Window.RibbonBarItems["命令"]["Run"].Image = Properties.Resources.play_48;
            SQLEditor.Window.RibbonBarItems["命令"]["Run"].Size = RibbonBarButton.MenuButtonSize.Large;
            SQLEditor.Window.RibbonBarItems["命令"]["Run"].Click += delegate
            {
                SQLEditor.Window.ExecuteSQL();
            };

            SQLEditor.Window.RibbonBarItems["功能"]["UDT"].Image = Properties.Resources.table_search_48;
            SQLEditor.Window.RibbonBarItems["功能"]["UDT"].Size = RibbonBarButton.MenuButtonSize.Large;
            SQLEditor.Window.RibbonBarItems["功能"]["UDT"].Click += delegate
            {
                new UDTTables().ShowDialog();
            };
        }

        #region Private
        private static QueryHelper _q;
        private static QueryHelper Q
        {
            get
            {
                if (_q == null)
                    _q = new QueryHelper();
                return _q;
            }
        }

        private static UpdateHelper _u;
        private static UpdateHelper U
        {
            get
            {
                if (_u == null)
                    _u = new UpdateHelper();
                return _u;
            }
        }
        #endregion

        public static DataTable Query(string cmd)
        {
            return Q.Select(cmd);
        }

        public static void Update(params string[] cmds)
        {
            Update((IEnumerable<string>)cmds);
        }

        public static void Update(IEnumerable<string> cmds)
        {
            U.Execute(cmds.ToList());
        }

        public static void SetMessage(string msg)
        {
            MotherForm.SetStatusBarMessage(msg);
        }
    }
}
