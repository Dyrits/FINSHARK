# FinShark

FinShark helps investors find relavent financial documents without the noise of short-term data.

## Configuration

The frontend reads its Financial Modeling Prep API key from `VITE_API_KEY`. Copy `.env.example` to `.env` and set your own key. `.env` is git-ignored. Note that Vite embeds this value in the built JavaScript, so it is visible to anyone using the app.
