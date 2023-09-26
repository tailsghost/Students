using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Students.Models.Decanat;

namespace Students.ViewModel;

    [ObservableObject]
    internal partial class MainWindowViewModel
    {
        [ObservableProperty] private ObservableCollection<Group> _groups;

        [ObservableProperty] private Group _selectedGroup;

        [ObservableProperty] private List<object> _compositeCollection;

        [ObservableProperty] private object _selectedCompositeValue;

        public MainWindowViewModel()
        {
            var student_index = 1;
            var student = Enumerable.Range(1, 10).Select(i => new Student
            {
                Name = $"Name {student_index}",
                Surname = $"Surname {student_index}",
                Patronymic = $"Patronymic {student_index}",
                Birthday = DateTime.Now,
                Rating = 0,
                Description = $"Description {student_index++}"
                
            });

            var group = Enumerable.Range(1, 20).Select(i => new Group
            {
                Name = $"Группа {i}",
                Students = new ObservableCollection<Student>(student),
            });

            Groups = new ObservableCollection<Group>(group);

            CompositeCollection = new() { "Hello Word", 42, Groups[1], group, };
        }









        [RelayCommand]
        private void onCreateGroup()
        {
            var max_group = Groups.Count + 1;
            var new_group = new Group
            {
                Name = $"Группа {max_group}",
                Students = new ObservableCollection<Student>()
            };

            Groups.Add(new_group);
        }

        [RelayCommand]
        private void onDeleteGroup()
        {
            if (Groups.Contains(_selectedGroup))
            {
                Groups.Remove(_selectedGroup);
            }
        }
    }

