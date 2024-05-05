# BONELAB Unofficial Docs

> 🚧 **Note:** These docs are still a heavy work-in-progress!

This repository holds the source code for the [BONELAB Unofficial Docs](https://lava-pals.github.io/bl-unofficial-docs/), a community-managed knowledge base for creating SDK mods.

## Contributing

If you're unsure about the process for contributing on GitHub, [check out this guide](https://docs.github.com/en/pull-requests/collaborating-with-pull-requests/proposing-changes-to-your-work-with-pull-requests/about-pull-requests) for information about creating pull requests.

Furthermore, if you're unsure about formatting, you can use [GitHub's guidelines](https://docs.github.com/en/contributing) to contribute to their documentation as a reference point. It contains good practices, style guides and more.

## Previewing Locally

[Quartz](https://quartz.jzhao.xyz) requires at least [Node v18.14](https://nodejs.org/en) and npm v9.3.1 to function correctly. Please make sure you have this installed on your machine before continuing.

Then, in your terminal of choice, enter the following commands line by line to initialise everything:

```sh
git clone https://github.com/Lava-Pals/bl-unofficial-docs.git
cd bl-unofficial-docs
npm i
npx quartz create
```

Once you've done that, run this command:

```sh
npx quartz build --serve
```

This will start a local web server to run your Quartz on your computer. Open a web browser and visit http://localhost:8080/ to view it.

For more information, see the [Quartz documentation](https://quartz.jzhao.xyz).
