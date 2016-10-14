<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

  <xsl:output method="xml"/>
  <xsl:template match="/">
    <!-- Rename the root element. -->
    <xsl:element name="Movies">
      <xsl:apply-templates select="DvdList/DVD" />
    </xsl:element>
  </xsl:template>

  <xsl:template match="DVD">
    <!-- Transform the <DVD> element into a new element
     named <DVD>, which will use attributes instead of nested elements. -->
    <xsl:element name="DVD">
      <!-- Keep the ID attribute. -->
      <xsl:attribute name="ID">
        <xsl:value-of select="@ID"/>
      </xsl:attribute>
      <!-- Put the nested <Title> text into an attribute. -->
      <xsl:attribute name="Title">
        <xsl:value-of select="Title/text()"/>
      </xsl:attribute>
      <xsl:apply-templates select="Starring/Star" />
    </xsl:element>
  </xsl:template>

  <xsl:template match="Star">
    <xsl:element name="Star">
      <!-- Put the nested <Star> text into an attribute. -->
      <xsl:attribute name="Name">
        <xsl:value-of select="text()"/>
      </xsl:attribute>
    </xsl:element>
  </xsl:template>

</xsl:stylesheet>


