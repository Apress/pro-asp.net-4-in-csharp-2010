<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeFile="SimpleAsyncPage.aspx.cs" Inherits="SimpleAsyncPage"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        This page uses asynchronous completion to execute a slow (30 second) task. To see
        how it works, watch the Output window in Visual Studio. You'll see that the first part of the page lifecycle
        is executed on a different thread than the last part.<br />
        <br />
        Keep in mind that this is an example of asynchronous pages, but it doesn't improve
        scalability because both asynchronous delegates and ASP.NET borrow from the same
        pool.
        <br />
        If Internet Explorer times out quickly (say, after just 10 seconds), the culprit may be that
        the ReceiveTimeout setting has been set on your computer (which some setup programs are known to do).
        To check for and resolve the problem, see http://intersoftpt.wordpress.com/2009/06/23/resolve-page-cannot-be-displayed-issue-in-ie8/.
    </div>
    </form>
</body>
</html>
