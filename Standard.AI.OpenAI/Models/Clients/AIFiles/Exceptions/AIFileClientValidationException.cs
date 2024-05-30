﻿// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace Standard.AI.OpenAI.Models.Clients.AIFiles.Exceptions
{
    /// <summary>
    /// This exception is thrown when a validation error occurs while using the AI file client.
    /// For example, if required data is missing or invalid
    /// </summary>
    public class AIFileClientValidationException : Xeption
    {
        public AIFileClientValidationException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}
