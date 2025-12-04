ARG base_tag=bookworm
ARG base_img=mcr.microsoft.com/vscode/devcontainers/base:dev-${base_tag}

FROM --platform=linux/amd64 ${base_img} AS builder-install

RUN apt-get update --fix-missing && apt-get -y upgrade
RUN apt-get install -y --no-install-recommends \
    apt-utils \
    curl \
    cmake \
    build-essential \
    gcc \
    g++-multilib \
    locales \
    make \
    gcovr \
    wget

RUN wget https://packages.microsoft.com/config/debian/13/packages-microsoft-prod.deb -O packages-microsoft-prod.deb \
    && sudo dpkg -i packages-microsoft-prod.deb \
    && rm packages-microsoft-prod.deb

RUN sudo apt-get update \
    && sudo apt-get install -y dotnet-sdk-10.0 \
    && rm -rf /var/lib/apt/lists/*