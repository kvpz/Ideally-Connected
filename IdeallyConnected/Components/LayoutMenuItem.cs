using System.Collections.Generic;

namespace IdeallyConnected.Components
{
    public class LayoutMenuItem
    {
        public LayoutMenuItem()
        {
            ParentId = 0;
            Menus = new List<LayoutMenuItem>();
        }

        #region Properties
        public int MenuId { get; set; }
        public int ParentId { get; set; }
        public string Title { get; set; }
        public int DisplayOrder { get; set; }
        public string Action { get; set; }
        #endregion

        public List<LayoutMenuItem> Menus { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}