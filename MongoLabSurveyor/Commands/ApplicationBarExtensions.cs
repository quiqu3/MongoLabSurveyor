using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoLabSurveyor.Commands
{
    public static class ApplicationBarExtensions
    {
        ///<summary>
        /// Finds an <see cref="ApplicationBarIconButton"/> by its name.
        ///</summary>
        ///<param name="appBar"></param>
        ///<param name="text"></param>
        ///<returns></returns>
        [CLSCompliant(false)]
        public static ApplicationBarIconButton FindButton(this IApplicationBar appBar, string text)
        {
            if (appBar == null) throw new ArgumentNullException("appBar");
            return (from object button in appBar.Buttons
                    select button as ApplicationBarIconButton).FirstOrDefault(btn => btn != null && btn.Text == text);
        }
    }
}
