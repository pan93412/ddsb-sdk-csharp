using System;

namespace ddsb_sdk
{
    public static class Errors
    {
        /// <summary>
        /// 10000: The given url is empty.
        /// </summary>
        public static Exception err10000 = new InvalidOperationException("The given url is empty.");
        /// <summary>
        /// 10001: The given url is malformed.
        /// </summary>
        public static Exception err10001 = new ArgumentException("The given url is malformed. Add the \"http://\" or \"https://\" prefix?");
        /// <summary>
        /// 10002: The given suffix is empty.
        /// </summary>
        public static Exception err10002 = new ArgumentException("The given suffix is empty.");
        /// <summary>
        /// 10003: The given password is empty.
        /// </summary>
        public static Exception err10003 = new ArgumentException("The given password is empty.");
        /// <summary>
        /// 10004: The given suffix has been used.
        /// </summary>
        public static Exception err10004 = new InvalidOperationException("The given suffix has been used.");
    }
}
