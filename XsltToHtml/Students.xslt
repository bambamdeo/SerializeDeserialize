<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
  <xsl:output method="html" indent="yes"/>

  <xsl:template match="/">
    <html>
      <head></head>
      <body>
        <xsl:for-each select="//Student">
          <div style="border:1px black solid;width:auto;margin:1px">

            <div style="display:inline-block;">
              <b>Student ID:</b>
              <xsl:value-of select="ID"/>
            </div>
            <div style="display:inline-block;">
              <b>Name:</b>
              <xsl:value-of select="Name"/>
              <xsl:text> </xsl:text>
              <xsl:value-of select="Surname"/>
            </div>
            <div style="display:inline-block;">
              <b>Course:</b>
              <xsl:value-of select="Course"/>
            </div>
            <div style="display:inline-block;">
              <b>Age:</b>
              <xsl:value-of select="Age"/>
            </div>
          </div>
        </xsl:for-each>
      </body>
    </html>
  </xsl:template>


</xsl:stylesheet>
