using System;
using System.Collections.Generic;
using System.Linq;
using IrmandadeNsg.Domain.Core.Events;
using Newtonsoft.Json;

namespace IrmandadeNsg.Application.EventSourcedNormalizers
{
    public class PostHistory
    {
        public static IList<PostHistoryData> HistoryData { get; set; }

        public static IList<PostHistoryData> ToJavaScriptPostHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<PostHistoryData>();
            PostHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.When);
            var list = new List<PostHistoryData>();
            var last = new PostHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new PostHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id? "": change.Id,
                    Title = string.IsNullOrWhiteSpace(change.Author) || change.Author == last.Author? "": change.Author,
                    Body = string.IsNullOrWhiteSpace(change.Body) || change.Body == last.Body ? "": change.Body,
                    Image = string.IsNullOrWhiteSpace(change.Image) || change.Image == last.Image ? "": change.Image,
                    Description = string.IsNullOrWhiteSpace(change.Description) || change.Description == last.Description ? "": change.Description,
                    Tags = string.IsNullOrWhiteSpace(change.Tags) || change.Tags == last.Tags ? "": change.Tags,
                    Category = string.IsNullOrWhiteSpace(change.Category) || change.Category == last.Category ? "": change.Category,
                    Created = string.IsNullOrWhiteSpace(change.Author) || change.Author == last.Author? "": change.Author,
                    MainComments = string.IsNullOrWhiteSpace(change.MainComments) || change.MainComments == last.MainComments ? "": change.MainComments,
                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    When = change.When,
                    Who = change.Who
                };

                list.Add(jsSlot);
                last = change;
            }
            return list;
        }

        private static void PostHistoryDeserializer(IEnumerable<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var slot = new PostHistoryData();
                dynamic values;

                switch (e.MessageType)
                {
                    case "PostRegisteredEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Title = values["Title"];
                        slot.Body = values["Body"];
                        slot.Image = values["Image"];
                        slot.Description = values["Description"];
                        slot.Tags = values["Tags"];
                        slot.Category = values["Category"];
                        slot.Created = values["Created"];
                        slot.MainComments = values["MainComments"];
                        slot.Action = "Registered";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                    case "PostUpdatedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Title = values["Title"];
                        slot.Body = values["Body"];
                        slot.Image = values["Image"];
                        slot.Description = values["Description"];
                        slot.Tags = values["Tags"];
                        slot.Category = values["Category"];
                        slot.Created = values["Created"];
                        slot.MainComments = values["MainComments"];
                        slot.Action = "Updated";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                    case "PostRemovedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Action = "Removed";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                }
                HistoryData.Add(slot);
            }
        }
    }
}