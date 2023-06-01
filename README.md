# MusiczBrainz API

## About the API:
The Api Expose two endpoints as per below : 

* ```/artist/search/<search_criteria>/<page_number>/<page_size>``` - Provide inforation about artist and their releases
* ```/artist/6c44e9c22-ef82-4a77-9bcd-af6c958446d6/albums``` - Provide information about albums of a specific artist

### Architecture and Solution Structure
The Api is a .net core application build upon .net 6.0 framework and is based on Minimal API architecture.

The two layer that made up the application are as follows: 

* **Layer 1:**  The API 
This thin layer create instances in lower layer and delegate functionality. There no business or domain logic involves , there are configuration and routes mapping.

* **Layer 2:**  The core
The second layer contains the main logic of the API and carried functionality of controllers passed down from the upper layer [MusicBrainzApi].
There three main folders each having different responsiblity, 

* Handler - handles /redirect request from the api 
* Models - define the properties and data representation for processing
* Persistence - IT holds data repositories which is the data source for the application

* A relational normalise data approach has been used for data structure rather storing jsaon blob into tables. The logic is to have an easier maintenance and not to have duplication of data.


## How to run the Apllication:

* clone the application repository to a local destination
* The application can be launch via cmd using *dotnet run* or launch the application via visual studio
* The api is configured to run on both Kestrel webserver and IIS [Additional setting may be required from local machine to run the application on IIS]

## How To Test
* Once the API is up and running there are samples of Api called / URls in the **postman collection** folder.  [Export the file Musicbrainz-Collection.postman_collection.json to postman]
* There is a unit test project which implements test for handlers , testing http reponse.

**Note** Execute sql script in order they are numbered in the script folder and change connection string accordingly [or used conection string if available]

**Sample url**
http://localhost:5035/artist/{ArtistId}/albums : The port may differ depending on port binding the api is been tested

** Log is available on console and seq **
A seq docker has been provided be to able to have better logging.Execute the following command after install docker:
*docker .\docker-compose.logging.yml up*


