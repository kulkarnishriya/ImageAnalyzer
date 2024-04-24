Image analyzer service uses azure cognitive service to categorize images based on trained dataset.
This service exposes below apis : 
1. /GetCategories : Lists various categories used to classify images
2. /GetImages : Lists all the images uploaded. The uploaded images are stored in blob storage
3. /CategoryByImage : Gets the image category based on imageId
4. /imageanalysis : Allows user to upload an image for image analysis

Services used : 
sql server : To store metadata
blob storage : To store uploaded image files
azure cognitive service : To train and perform image analysis
