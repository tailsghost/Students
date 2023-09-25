﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using Students.Models.Decanat;

namespace Students.ViewModel;

    [ObservableObject]
    internal partial class MainWindowViewModel
    {
        [ObservableProperty] public ObservableCollection<Group> _groups;

        public MainWindowViewModel()
        {
            var student_index = 1;
            var student = Enumerable.Range(1, 10).Select(i => new Student
            {
                Name = $"Name {student_index}",
                Surname = $"Surname {student_index}",
                Patronymic = $"Patronymic {student_index++}",
                Birthday = DateTime.Now,
                Rating = 0
            });

            var group = Enumerable.Range(1, 20).Select(i => new Group
            {
                Name = $"Группа {i}",
                Students = new ObservableCollection<Student>(student)
            });

            Groups = new ObservableCollection<Group>(group);
        }
    }

