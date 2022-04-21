// Decompiled with JetBrains decompiler
// Type: RISHI_WIP.Reports.CrystallReports.CachedWEAVING
// Assembly: RISHI_WIP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AADE7ADB-8EB8-48EA-8AF7-5E9EEE5C2D53
// Assembly location: C:\Users\sar.puttaraju.ah\Desktop\RISHI_WIP\New folder\RISHI_WIP.exe

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using System;
using System.ComponentModel;
using System.Drawing;

namespace RISHI_WIP.Reports.CrystallReports
{
  [ToolboxBitmap(typeof (ExportOptions), "report.bmp")]
  public class CachedWEAVING : Component, ICachedReport
  {
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual bool IsCacheable
    {
      get => true;
      set
      {
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual bool ShareDBLogonInfo
    {
      get => false;
      set
      {
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual TimeSpan CacheTimeOut
    {
      get => CachedReportConstants.DEFAULT_TIMEOUT;
      set
      {
      }
    }

    public virtual ReportDocument CreateReport()
    {
      WEAVING report = new WEAVING();
      report.Site = this.Site;
      return (ReportDocument) report;
    }

    public virtual string GetCustomizedCacheKey(RequestContext request) => (string) null;
  }
}
