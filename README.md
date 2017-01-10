# ImageBaconCypher
This is a proof-of-concept application to develop a method for storing incrypted text inside image data.

The entered text is encrypted, using the user-supplied password's hash as a salt.  A Bacon Cypher is then generated, using the hash
of the password as a seed to randomize the cypher.  Each byte value from the encrypted output is then converted to the cypher,
and embedded into the image by altering the least significant bit of each pixel to match the byte's cypher text as an even/odd value.

A 5-digit cypher is used, so each encrypted byte uses 2 pixels of the source image.

A future version of the concept could be implemented to use a public/private key encryption algorithm, which would allow users
to post images to a website, with messages only accessible to the owner of the private key, without the two communicators to
ever need to contact each other.  Even the initial exchange of public keys could be mediated by the website.
