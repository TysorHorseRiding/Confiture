using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;

namespace Miseajour
{
    public interface IMiseajour
    {
        string ApplicationName { get; }
        string ApplicationID { get; }
        Assembly ApplicationAssembly { get; }
        Icon ApplicationIcon { get; }
        Uri UpdateXmlLocation { get; }
        Form Context { get; }

    }
}
