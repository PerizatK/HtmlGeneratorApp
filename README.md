# HtmlGeneratorApp

Download the publish.7z file to run the application without needing to compile it.

The ProductItem class acts as the data model representing the JSON data.

The HtmlGenerator class is responsible for generating HTML from JSON data based on an HTML template. Its main method, CreateHtml, requires a template string and a JSON string as parameters.

Additionally, the class contains private methods:
- MatchDataWithPattern: This method, called from CreateHtml, matches the JSON data with the specified pattern.
- LoadJson: This method, also called from CreateHtml, handles the loading of JSON data.
  
