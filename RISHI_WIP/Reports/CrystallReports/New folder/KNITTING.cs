// Decompiled with JetBrains decompiler
// Type: RISHI_WIP.Reports.CrystallReports.KNITTING
// Assembly: RISHI_WIP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AADE7ADB-8EB8-48EA-8AF7-5E9EEE5C2D53
// Assembly location: C:\Users\sar.puttaraju.ah\Desktop\RISHI_WIP\New folder\RISHI_WIP.exe

using CrystalDecisions.CrystalReports.Engine;
using System.ComponentModel;

namespace RISHI_WIP.Reports.CrystallReports
{
  public class KNITTING : ReportClass
  {
    public override string ResourceName
    {
      get => "KNITTING.rpt";
      set
      {
      }
    }

    public override bool NewGenerator
    {
      get => true;
      set
      {
      }
    }

    public override string FullResourceName
    {
      get => "RISHI_WIP.Reports.CrystallReports.KNITTING.rpt";
      set
      {
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Section Section1 => this.ReportDefinition.Sections[0];

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Section Section2 => this.ReportDefinition.Sections[1];

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Section Section3 => this.ReportDefinition.Sections[2];

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Section Section4 => this.ReportDefinition.Sections[3];

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Section Section5 => this.ReportDefinition.Sections[4];
  }
}
