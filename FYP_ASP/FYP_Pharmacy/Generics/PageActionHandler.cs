using Logger;
using System.Reflection;
using System.Web.UI;

namespace Generics
{
    public class PageActionHandler : Page
    {
        protected MessageCollection MessageCollection = new MessageCollection();
        protected string PageName;
        protected string CONTEXT;
        protected MethodBase method;
        protected Logging log = new Logging();
    }
}
