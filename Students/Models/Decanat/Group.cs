﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Students.Models.Decanat;

[ObservableObject]
internal partial class Group
{
    [ObservableProperty] public string _name;

    [ObservableProperty] public IList<Student> _students;

    public string Description { get; set; }


}

