using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiskSpaceWatcher {
    public class Threshold : IComparable<Threshold> {

        private long _value;
        private string _label;

        public long Value {
            get { return _value; }
            set {
                _value = value;
                _label = Program.BytesToString(_value);
            }
        }

        public string Label { get { return _label; } }

        public Threshold(long value) {
            Value = value;
        }

        public override string ToString() {
            return _label;
        }

        public int CompareTo(Threshold other) {
            return this.Value.CompareTo(other.Value);
        }
    }

    public class Thresholds : Dictionary<long, Threshold> {
        public Thresholds(string source) {
            if (String.IsNullOrEmpty(source)) { throw new ArgumentNullException("source"); }
            source.Split(new[] { " ", "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(value => value.TryParse<long>().ToThreshold())
                .ToList()
                .ForEach(threshold => { this[threshold.Value] = threshold; });
        }

        public List<Threshold> ToList() {
            var list = this.Values.ToList();
            list.Sort();
            return list;
        }

        public new Threshold this[long key] {
            get {
                return base.ContainsKey(key)
                    ? base[key]
                    : this.ToList().First();
            }
            set { base[key] = value; }
        }
    }

    public static class ThresholdHelper {
        public static Threshold ToThreshold(this long value) {
            return new Threshold(value);
        }

        public static Thresholds ToThresholds(this string source) {
            return new Thresholds(source);
        }
    }
}
