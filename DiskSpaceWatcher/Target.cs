﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DiskSpaceWatcher {
    public class Target : IComparable<Target> {
        private const string _separator = ";";

        public string Drive { get; set; } 

        public long Warning { get; set; } 

        public long Caution { get; set; } 

        public Target(string drive, long warning, long caution) {
            Drive = drive;
            Warning = warning;
            Caution = caution;
        }

        public Target(string source) {
            var items = source.Split(new string[] { _separator }, StringSplitOptions.RemoveEmptyEntries)
                .Select(item => item.Trim())
                .ToArray();
            if (items.Length < 3) { throw (new Exception($"Invalid source: {source}")); }
            Drive = items[0];
            Warning = items[1].TryParse<long>(53687091200);
            Caution = items[2].TryParse<long>(214748364800);
        }

        public override string ToString() {
            return String.Join(
                $"{_separator} ",
                new[] { Drive, Warning.ToString(), Caution.ToString() }
            );
        }

        public int CompareTo(Target other) {
            return this.Drive.CompareTo(other.Drive);
        }
    }

    public class Targets : Dictionary<string, Target> {
        private const string _separator = "\n";

        public Targets(string source = null) {
            if (String.IsNullOrEmpty(source)) { return; }
            source.Split(new string[] { _separator }, StringSplitOptions.RemoveEmptyEntries)
                  .Select(src => src.ToTarget())
                  .ToList()
                  .ForEach(target => { this[target.Drive] = target; });
        }

        public List<string> Drives {
            get {
                var drives = this.Keys.ToList();
                drives.Sort();
                return drives;
            }
        }

        public List<Target> ToList() {
            var list = this.Values.ToList();
            list.Sort();
            return list;
        }

        public override string ToString() {
            return String.Join(_separator, ToList());
        }
    }

    public static class TargetHelper {
        public static Target ToTarget(this string source) {
            if (String.IsNullOrEmpty(source)) { return null; }
            return new Target(source);
        }
        public static Targets ToTargets(this string source) {
            if (String.IsNullOrEmpty(source)) { return null; }
            return new Targets(source);
        }
    }
}
