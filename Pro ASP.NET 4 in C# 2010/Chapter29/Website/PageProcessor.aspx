<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PageProcessor.aspx.cs" Inherits="PageProcessor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript">
	var iLoopCounter = 1;
	var iMaxLoop = 6;
	var iIntervalId;
	
	function BeginPageLoad()
	{
	    // Redirect the browser to another page while keeping focus.
		location.href = "<%=PageToLoad %>";
		// Update progress meter every 1/2 second.
		iIntervalId = window.setInterval("iLoopCounter=UpdateProgressMeter(iLoopCounter,iMaxLoop);", 500);
	}
	function EndPageLoad()
	{
		window.clearInterval(iIntervalId);

		// Find the object that represents the progress meter.
        var progressMeter = document.getElementById("ProgressMeter")
		progressMeter.innerHTML = "Page Loaded - Now Transfering";
	}
	function UpdateProgressMeter(iCurrentLoopCounter, iMaximumLoops)
	{
		var progressMeter = document.getElementById("ProgressMeter")
		
		iCurrentLoopCounter += 1;
		if(iCurrentLoopCounter <= iMaximumLoops)
		 {
			progressMeter.innerHTML += ".";
			return iCurrentLoopCounter;			
		 }
		else
		 {
			progressMeter.innerHTML = "";
			return 1;
		 }
	}	
		</script>
	</head>
	<body onload="BeginPageLoad();" onunload="EndPageLoad();">

    <form id="form1" runat="server">
    <div>
    <table border="0" width="99%">
		<tr>
			<td align="center" valign="middle">
				<span id="MessageText" style="font-size:x-large; font-weight:bold">Loading Page - Please Wait</span>
			    <span id="ProgressMeter" ></span>
			</td>
		</tr>
	</table>
    </div>
    </form>
</body>
</html>
