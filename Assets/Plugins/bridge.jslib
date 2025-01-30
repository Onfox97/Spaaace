mergeInto(LibraryManager.library,
{
    AddScore: function(playerName,playerScore)
    {
        addScore(Pointer_stringify(playerName), playerScore);
    },
});