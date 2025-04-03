namespace ChatEventAggregator.Common.Domain;

public record ChatEventStats(int RoomEntersCount, int RoomLeavesCount, int CommentsCount, int HighFivesFromCount, int HighFivesToCount);