using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
namespace HELPER
{
    public class GridViewTemplate : ITemplate
    {
         
        private string text;

        public GridViewTemplate( string text)
        {
            this.text = text;
        }

        public void InstantiateIn(System.Web.UI.Control container)
        {
            LinkButton lb = new LinkButton();
            lb.EnableViewState = true;
            lb.Text = text;
            container.Controls.Add(lb); 

                 
        }
    } 
  

}
