using System;

namespace ddsb_sdk
{
    public static class Errors
    {
        public static Exception err10000 = new InvalidOperationException("The given url is empty.");
        public static Exception err10001 = new ArgumentException("The given url is malformed. Add the \"http://\" or \"https://\" prefix?");
        public static Exception err10002 = new ArgumentException("The given suffix is empty.");
        public static Exception err10003 = new ArgumentException("The given password is empty.");
        public static Exception err10004 = new InvalidOperationException("The given suffix has been used.");
    }
}
