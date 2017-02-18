using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using IdeallyConnected.Utility.Components;

namespace IdeallyConnected.Components
{
    public class LayoutMenuItemManager
    {
        public List<LayoutMenuItem> Menus { get; set; }

        // Returns a list of the XML elements
        public List<LayoutMenuItem> Load(string location)
        {
            XElement menus = XElement.Load(location);

            Menus = LoadMenus(menus, 0);

            return Menus;
        }

        // Returns all elements with the ParentId
        private List<LayoutMenuItem> LoadMenus(XElement menus, int ParentId)
        {
            List<LayoutMenuItem> nodes = new List<LayoutMenuItem>();
            
            nodes = 
                (from node in menus.Elements("Menu")
                 where node.Element("ParentId").GetAs<int>() == ParentId
                 orderby node.Element("DisplayOrder"). GetAs<int>()
                 select new LayoutMenuItem
                 {
                    MenuId = node.Element("MenuId").GetAs<int>(),
                    ParentId = node.Element("ParentId").GetAs<int>(),
                    Title = node.Element("Title").Value,
                    DisplayOrder = node.Element("DisplayOrder").GetAs<int>(),
                    Action = node.Element("Action").Value,
                    Menus = (MenuItems(ref menus, node, ParentId))
                 }).ToList();

            return nodes;
        }

        // Return drop down menu items (XML children elements of node)
        private List<LayoutMenuItem> MenuItems(ref XElement menus, XElement node, int ParentId)
        {
            return (
                ParentId != node.Element("MenuId").GetAs<int>() ?
                LoadMenus(menus, node.Element("MenuId").GetAs<int>()) :
                new List<LayoutMenuItem>()
                );
        }
        
    }
}