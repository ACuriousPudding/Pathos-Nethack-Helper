# Purpose
The purpose of the Pathos-Quest-Parser is to consume a .Quest file and render it in a more human-readable format. This includes a graphical (ascii) representation of the map data, as well as a queryable format of the non-map data (such as entities and metadata).

In the case of the Lost Chambers (Chambers.Quest), the Pathos_Nethack_Helper.PathosQuestParser.Quest object should be able to provide the portal information that would reproduce the data we manually recorded in Pathos_Nethack_Helper.LostChambers.PortalData._originalPortalData.

# Overview of Structure
The Main method in the Program class is the entry point into the application. It creates a Quest object with the filepath information it is provided. The Quest object then delegates tokenization and parsing to the Tokenizer class, which builds TokenGroup objects from the provided .Quest file. These TokenGroups are returned to the Quest object, where they are organized and stored by type.

The Quest object then provides methods for querying and accessing the tokenized data, such as rendering the Map TokenGroups, querying the Site information, or finding all Character entries of a given type.