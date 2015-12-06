# Microsoft.ReportViewer.Web
Dependent libraries to use Microsoft.ReportViewer in MVC or WebForms. Includes DataVisualization to be able to render chart controls. Works with both MVC and WebForms. 


#Sample
Download project __mvc.reporting__

See

 * /controllers/HomeController
 * /Bll/Report.cs



#Install via Nuget
[https://www.nuget.org/packages/Microsoft.ReportViewer.Web.2012/](https://www.nuget.org/packages/Microsoft.ReportViewer.Web.2012/)


<div class="nuget-badge">
    <p>
        <code>
            PM&gt; Install-Package Microsoft.ReportViewer.Web.2012
        </code>
    </p>
</div>

#Prerequisites
Microsoft System CLR Types for Microsoft SQL Server 2012
https://www.microsoft.com/en-us/download/details.aspx?id=29065


or nuget package "[Microsoft.SqlServer.Types >= 11.0.2](https://www.nuget.org/packages/Microsoft.SqlServer.Types/)"

but i find it adds too many dependencies, so having sql server types on server is probably a better solution.

