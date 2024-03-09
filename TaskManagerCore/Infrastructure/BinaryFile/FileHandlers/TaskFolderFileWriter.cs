﻿using TaskManagerCore.Infrastructure.BinaryFile.Entity;
using TaskManagerCore.Infrastructure.BinaryFile.FileHandlers.Helper;

namespace TaskManagerCore.Infrastructure.BinaryFile.FileHandlers
{
    internal class TaskFolderFileWriter : BinaryFileWriter<TaskFolderEntity>
    {
        public TaskFolderFileWriter(string filename = "folder-data", string? rootPath = null)
            : base(filename, rootPath)
        { }

        protected override void WriteObject(BinaryWriter writer, TaskFolderEntity entity)
        {
            writer.Write(entity.Id);
            writer.Write(entity.Name);
            var concatString = string.Join(Delimiter, entity.TaskIds);
            writer.Write(concatString);
        }

        protected override void WriteTerminatorObject(BinaryWriter writer)
        {
            writer.Write(TaskFolderTerminator.IdTerminator);
            writer.Write(TaskFolderTerminator.NameTerminator);
            var concatString = string.Join(Delimiter, TaskFolderTerminator.TaskIdsTerminator);
            writer.Write(concatString);
        }
    }
}