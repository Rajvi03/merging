kalyanjewellers

frontend - Angular
Backend - Dotnet
Database: MSSQL

- user can see all the products
- user can add the products in cart
- user can purchase the product

- user can SignUp by
    - Enter Full Name
    - Email
    - Mobile No.

- user can login with email / mobile no


tables

Feedback
- FeedbackID
- FirstName
- LastName 
- Mobile No.
- Email
- FeedBackType : Store Related Complaint
                  Product Related Complaint
                  General Queries
                  Other Queries

Users 
- UsersID
- FirstName
- LastName
- Email
- MobileNo
- Password
- AlternateMobileNo
- Gender
- UserRole
- DOB
- AnniversaryDate
- Company
- StreetAddress
- StreetAddress2
- ZipCode
- City
- State
- Country
- SubscribersID

Subscribers
- SubscribersID
- Email
- MobileNo

productParentCategory
- productParentCategoryID
- PCategoryName

- GOLD
- DIAMOND
- PEARL
- WHITE GOLD
- GEMSTONE
- PLATINUM

productSubCategory
- productSubCategoryID
- productParentCategoryID
- SCategoryName

- CHAINS
- RINGS
- NECKLACES
- EARRINGS
- BRACELETS
- BANGLES
- Kada

ProductDesign
- ProductDesignID
- productSubCategoryID
- ProductDesignName

Products
- ProductID
- ProductName
- ProductDescription
- SKU


ProductDetails
- ProductDetailsID
- ProductID
- StyleNo
- Height
- TotalWeight
- size
- MetalWeight
- CreatedDate
- ProductDesignID
- UserCategory refere ObjectID
- MetalColor refere ObjectID
- Metalpurity refere ObjectID
- ProductStatus refere ObjectID
- MetalPrice
- MakingCharges



DiamondDetails
- DiamondDetailsID
- ProductDetailsID
- TotalNoOfDiamonds
- TotalWeight
- Clarity refere ObjectID
- Color
- SettingType
- Shape
- DiamondWeight

Images
- ImagesID
- ProductDetailsID
- ImageName
- ImageURL

Discount
- DiscountID 
- ProductDetailsID
- DiscountPercentage
- DateStart	
- DateEnd

WishList
- WishListID
- UserID
- ProductID


Cart
- CartID
- UserID
- CartTotal

CartDetail
- CartDetailID
- CartID
- ProductID
- Quntity

OrderAddress
- OrderAddressID
- UserID
- Company
- StreetAddress
- StreetAddress2
- ZipCode
- City
- State
- Country


Order
- OrderID
- UsersID
- CartDetailID
- OrderAddressID
- OrderDate
- OrderAmount
- DiscountAmount
- PayableAmount


Type
- TypeID
- TypeName
    - 1 Gender
    - 2 MetalColor
    - 3 MetalPurity
    - 4 DiamondQuality
    - 6 ProductStatus
    - 7 FeedBackType

Object 
ObjectID, TypeID, value
- 1, 1, Male
- 2, 1, Female
- 3, 1, Kids
- 4, 1, Unisex
- 5, 2, White Gold
- 6, 2, Yellow Gold
- 7, 2, Rose Gold
- 8, 2, Platinum
- 9, 3, 14k
- 10, 3, 18k
- 11, 4, SI IJ
- 12, 4, SI GH
- 13, 4, VS GH
- 14, 4, VVS EF
- 15, 4, 12 GH
- 16, 5, Instock
- 17, 5, Outstock
- 18, 7, Store Related Complaint
- 19, 7, Product Related Complaint
- 20, 7, General Queries
- 21, 7,  Other Queries


