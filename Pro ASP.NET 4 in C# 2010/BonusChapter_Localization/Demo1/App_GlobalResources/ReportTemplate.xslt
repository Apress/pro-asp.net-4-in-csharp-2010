<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <h1>Person Report</h1>
    <p>
      This report has been generated for demonstrating usage of resources.
      It gets input from an XML file stored in the resources as a template as
      well and transforms the content into a nice looking report (hopefully nice
      looking;)).
    </p>
    <table>
      <tr>
        <td><b>Firstname:</b></td>
        <td>
          <xsl:value-of select=".//Firstname" />
        </td>
      </tr>
      <tr>
        <td><b>Lastname:</b></td>
        <td>
          <xsl:value-of select=".//Lastname"/>
        </td>
      </tr>        
      <tr>
        <td><b>Age:</b></td>
        <td>
          <xsl:value-of select=".//Age" />
        </td>
      </tr>
    </table>
  </xsl:template>
</xsl:stylesheet> 

