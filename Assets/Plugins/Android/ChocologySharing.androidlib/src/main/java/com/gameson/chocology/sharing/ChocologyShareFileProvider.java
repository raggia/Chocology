package com.gameson.chocology.sharing;

import androidx.core.content.FileProvider;

/** A distinct provider avoids manifest collisions with SDK-owned FileProvider declarations. */
public final class ChocologyShareFileProvider extends FileProvider {
    public ChocologyShareFileProvider() {
        super();
    }
}
