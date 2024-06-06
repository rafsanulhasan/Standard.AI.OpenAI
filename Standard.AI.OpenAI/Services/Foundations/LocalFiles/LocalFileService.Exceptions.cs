﻿// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using System.IO;
using Standard.AI.OpenAI.Models.Services.Foundations.LocalFiles.Exceptions;

namespace Standard.AI.OpenAI.Services.Foundations.LocalFiles
{
    internal partial class LocalFileService
    {
        private delegate Stream ReturningStreamFunction();

        private Stream TryCatch(ReturningStreamFunction returningStreamFunction)
        {
            try
            {
                return returningStreamFunction();
            }
            catch (InvalidLocalFileException invalidFileException)
            {
                throw new LocalFileValidationException(invalidFileException);
            }
            catch (ArgumentException argumentException)
            {
                var invalidFileException =
                    CreateInvalidLocalFileException(
                        argumentException);

                throw new LocalFileDependencyValidationException(invalidFileException);
            }
            catch (PathTooLongException pathTooLongException)
            {
                var invalidFileException =
                    CreateInvalidLocalFileException(
                        pathTooLongException);

                throw new LocalFileDependencyValidationException(invalidFileException);
            }
            catch (FileNotFoundException fileNotFoundException)
            {
                var notFoundFileException =
                    new NotFoundLocalFileException(fileNotFoundException);

                throw new LocalFileDependencyValidationException(notFoundFileException);
            }
            catch (DirectoryNotFoundException directoryNotFoundException)
            {
                var notFoundFileException =
                    new NotFoundLocalFileException(directoryNotFoundException);

                throw new LocalFileDependencyValidationException(notFoundFileException);
            }
            catch (IOException ioException)
            {
                var failedFileException =
                    new FailedLocalFileDependencyException(ioException);

                throw new LocalFileDependencyException(failedFileException);
            }
            catch (NotSupportedException notSupportedException)
            {
                var failedFileException =
                    new FailedLocalFileDependencyException(notSupportedException);

                throw new LocalFileDependencyException(failedFileException);
            }
            catch (Exception exception)
            {
                var failedLocalFileServiceException =
                    new FailedLocalFileServiceException(exception);

                throw new LocalFileServiceException(failedLocalFileServiceException);
            }
        }

        private static InvalidLocalFileException CreateInvalidLocalFileException(Exception innerException)
        {
            return new InvalidLocalFileException(
                message: "Invalid local file error occurred, fix error and try again.",
                innerException);
        }
    }
}
