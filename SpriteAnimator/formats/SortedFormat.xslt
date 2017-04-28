<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
  <xsl:output method="xml" encoding="utf-8" omit-xml-declaration="no" indent="yes" />
  <xsl:template match="/format">
    <xsl:element name="format">
      <xsl:copy-of select="@*"/>
      <xsl:element name="reference">
        <xsl:for-each select="reference/protected-colors">
          <xsl:copy-of select="."/>
        </xsl:for-each>
      </xsl:element>
      <xsl:element name="guides">
        <xsl:for-each select="guides/guide">
          <xsl:sort select="@type" data-type="text" order="ascending"/>
          <xsl:sort select="@value" data-type="number" order="ascending"/>
          <xsl:copy-of select="."/>
        </xsl:for-each>
      </xsl:element>
      <xsl:element name="colors">
        <xsl:for-each select="colors/color">
          <xsl:sort select="@name" data-type="text" order="ascending"/>
          <xsl:copy-of select="."/>
        </xsl:for-each>
      </xsl:element>
      <xsl:element name="sounds">
        <xsl:for-each select="sounds/sound">
          <xsl:sort select="@name" data-type="text" order="ascending"/>
          <xsl:copy-of select="."/>
        </xsl:for-each>
      </xsl:element>
      <xsl:element name="motion-tweens">
        <xsl:for-each select="motion-tweens/motion-tween">
          <xsl:sort select="@id" data-type="number" order="ascending"/>
          <xsl:copy-of select="."/>
        </xsl:for-each>
      </xsl:element>
      <xsl:element name="named-attachment-points">
        <xsl:for-each select="named-attachment-points/named-attachment-point">
          <xsl:sort select="@id" data-type="number" order="ascending"/>
          <xsl:element name="named-attachment-point">
            <xsl:for-each select="@*[
                  not(
                      (name()='x' and .='0.5') or
                      (name()='y' and .='0.5') or
                      (name()='description' and .='')
                  )
               ]">
              <xsl:copy-of select="."/>
            </xsl:for-each>
          </xsl:element>
        </xsl:for-each>
      </xsl:element>
      <xsl:element name="composite-frame-sets">
        <xsl:for-each select="composite-frame-sets/composite-frame-set">
          <xsl:sort select="@name" data-type="text" order="ascending"/>
          <xsl:copy-of select="."/>
        </xsl:for-each>
      </xsl:element>
      <xsl:element name="frames">
        <xsl:for-each select="frames/frame">
          <xsl:sort select="@id" data-type="number" order="ascending"/>
          <xsl:copy-of select="."/>
        </xsl:for-each>
      </xsl:element>
      <xsl:element name="composite-frames">
        <xsl:for-each select="composite-frames/composite-frame">
          <xsl:sort select="@id" data-type="number" order="ascending"/>
          <xsl:element name="composite-frame">
            <xsl:copy-of select="@*"/>
            <xsl:for-each select="node()">
              <xsl:if test="name()='frame'">
                <xsl:element name="frame">
                  <xsl:copy-of select="@*[
                     not(
                         (name()='flip-x' and .='False') or
                         (name()='offset-x' and .='0') or
                         (name()='offset-y' and .='0') or
                         (name()='offset-z' and .='0') or
                         (name()='rotation-z' and .='0') or
                         (name()='scale-x' and .='1') or
                         (name()='scale-y' and .='1')
                     )
                  ]"/>
                </xsl:element>
              </xsl:if>
              <xsl:if test="name()='sound'">
                <xsl:copy-of select="." />
              </xsl:if>
            </xsl:for-each>
          </xsl:element>
        </xsl:for-each>
      </xsl:element>
    </xsl:element>
  </xsl:template>
</xsl:stylesheet>
