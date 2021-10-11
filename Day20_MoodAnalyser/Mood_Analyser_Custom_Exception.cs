﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Day20_MoodAnalyser
{
    public class Mood_Analyser_Custom_Exception : Exception
    {
        public enum ExceptionType
        {
            NULL_MESSAGE,
            EMPTY_MESSAGE,
            NO_SUCH_FIELD,
            NO_SUCH_METHOD,
            NO_SUCH_CLASS,
            OBJECT_CREATION_ISSUE
        }
        private readonly ExceptionType type;
        public Mood_Analyser_Custom_Exception(ExceptionType Type, String message) : base(message)
        {
            this.type = Type;
        }
    }
}

