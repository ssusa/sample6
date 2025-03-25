using System;
using System.Collections.Generic;

namespace sample6.Models;

public partial class SampleTable
{
    public int Id { get; set; }

    public int? IntColumn1 { get; set; }

    public int? IntColumn2 { get; set; }

    public string? VarcharColumn1 { get; set; }

    public string? VarcharColumn2 { get; set; }

    public string? VarcharColumn3 { get; set; }

    public DateTime? CreatedColumn1 { get; set; }

    public DateTime? ModifyColumn2 { get; set; }
}
